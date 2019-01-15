using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IMUSE
{
    class SerialPortManager
    {

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        const int CLICK_TIME = 500;
        const int DOUBLE_CLICK_TIME = 200;
        const int CALIBRATION_ITERATION = 200;
        const double CALIBRATION_SAFETY = 0.3;
        const double Z_MIN = 45;
        const double Z_MAX = 57;
        const double MAX_CALIBRATION = 43;
        const double MIN_CALIBRATION = 41;
        const double X_MOVE = 11;
        const double Y_MOVE = 11;
        
        double xMin = 0;
        double xMax = 0;
        double yMin = 0;
        double yMax = 0;

        Stopwatch doubleClickTime = new Stopwatch();
        Stopwatch clickTime = new Stopwatch();
        
        bool couldBeDoubleClick = false;
        bool isLeftClick = false;
        bool isRightClick = false;
        bool wasClicked = false;
        bool wasCalibrated = false;
        int calibrationIterations = 0;
        double lastDifferenceX = 0.0;
        double lastDifferenceY = 0.0;
        double PX = 0.0;
        double IX = 0.0;
        double DX = 0.0;
        double PY = 0.0;
        double IY = 0.0;
        double DY = 0.0;
        double kP = 1.0;
        double kI = 0.02;
        double kD = 0.02;

        Form1 form;

        /*double lastX = 0;
        double lastY = 0;
        double lastZ = 0;*/

        private SerialPort port = new SerialPort("COM9", 9600, Parity.None, 8, StopBits.One);

        // Create the serial port with basic settings 
        public SerialPortManager(Form1 form)
        {
            this.form = form;
            Thread readPort = new Thread(StartPort);
            readPort.Start();
        }

        private void StartPort()
        {
            // Attach a method to be called when there
            // is data waiting in the port's buffer 
            port.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
            // Begin communications 
            port.Open();

        }

        private void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Show all the incoming data in the port's     
            try
            {
                string s = port.ReadLine();
                //Console.WriteLine(s);
                string[] components = s.Split(' ');

                double x = Double.Parse(components[1]);
                double y = Double.Parse(components[0]);
                double z = Double.Parse(components[2]);

                form.SetX(x);
                form.SetY(y);
                form.SetZ(z);
                form.SetZMax(Z_MAX);
                form.SetZMin(Z_MIN);

                if (!wasCalibrated)
                    CalibrateMouse(x, y);

                if (!IsClick(z) && wasCalibrated)
                {
                   bool isMouseMoving = MoveMouse(x, y);
                }
            }
            catch (Exception)
            {

            }
        }

        private void CalibrateMouse(double x, double y)
        {
            if (calibrationIterations <= CALIBRATION_ITERATION)
            {
                // change ranges
                xMax = xMax == 0 && x < MAX_CALIBRATION ? x : xMax;
                yMax = yMax == 0 && y < MAX_CALIBRATION? y : yMax;
                xMin = xMin == 0 && x > MIN_CALIBRATION? x : xMin;
                yMin = yMin == 0 && y > MIN_CALIBRATION? y : yMin;

                xMax = x < MAX_CALIBRATION && x > xMax ? x : xMax;
                yMax = y < MAX_CALIBRATION && y > yMax ? y : yMax;
                xMin = x > MIN_CALIBRATION && x < xMin ? x : xMin;
                yMin = y > MIN_CALIBRATION && y < yMin ? y : yMin;

                // update status
                form.SetXMax(xMax);
                form.SetXMin(xMin);
                form.SetYMax(yMax);
                form.SetYMin(yMin);
                form.SetProgress(calibrationIterations);

                calibrationIterations++;
            }
            else if (!wasCalibrated)
            {
                // add a safety 
                xMax += CALIBRATION_SAFETY;
                yMax += CALIBRATION_SAFETY;
                xMin -= CALIBRATION_SAFETY;
                yMin -= CALIBRATION_SAFETY;

                form.SetXMax(xMax);
                form.SetXMin(xMin);
                form.SetYMax(yMax);
                form.SetYMin(yMin);
               
                wasCalibrated = true;
            }
        }

        private bool IsClick(double z)
        {
            if (z > Z_MAX)
            {
                //double click
                if (couldBeDoubleClick && clickTime.IsRunning && clickTime.ElapsedMilliseconds < CLICK_TIME)
                {
                    DoLeftClick();
                    clickTime.Restart();
                    wasClicked = true;
                    form.SetStatusZ("Double Clic");
                }
                
                if (!wasClicked)
                {
                    DoLeftClick();
                    wasClicked = true;
                    isLeftClick = true;
                    clickTime.Start();
                }
            }

            if (z < Z_MIN && !wasClicked) {

                DoRightClick();
                wasClicked = true;
                clickTime.Start();
            }

            if (z >= Z_MIN && z <= Z_MAX)
            {
                if (isLeftClick)
                {
                    couldBeDoubleClick = true;
                }

                if (clickTime.ElapsedMilliseconds > CLICK_TIME)
                {
                    //reset flags and times
                    wasClicked = false;
                    isLeftClick = false;
                    isRightClick = false;
                    couldBeDoubleClick = false;
                    clickTime.Reset();
                }
            }

            return wasClicked;
        }

        private bool MoveMouse(double x, double y)
        {
            int movementX = 0;
            int movementY = 0;
            double differenceX = 0.0;
            double differenceY = 0.0;
            bool isMoving = false;

            // move to right;
            if (x < xMin) {
                differenceX = (xMin - x) / (xMax - xMin);
                form.SetStatusX("Dreta");
                isMoving = true;
            }
            // move to left
            else if (x > xMax)
            {
                differenceX = (xMax - x) / (xMax - xMin);
                form.SetStatusX("Esquerra");
                isMoving = true;
            }
            else
            {
                form.SetStatusX("Ociós");
            }

            // move to up;
            if (y < yMin)
            {
                differenceY = (y - yMin) / (yMax - yMin);
                form.SetStatusY("Dalt");
                isMoving = true;
            }
            // move to down
            else if (y > yMax)
            {
                differenceY = (y - yMax) / (yMax - yMin);
                form.SetStatusY("Baix");
                isMoving = true;
            }
            else
            {
                form.SetStatusY("Ociós");
            }

            PX = differenceX * X_MOVE * kP;
            IX = (IX + differenceX) * X_MOVE * kI;
            DX = (differenceX - lastDifferenceX) * X_MOVE * kD;
            movementX = (int)(PX + IX + DX);
            lastDifferenceX = differenceX;

            PY = differenceY * Y_MOVE * kP;
            IY = (IY + differenceY) * Y_MOVE * kI;
            DY = (differenceY - lastDifferenceY) * Y_MOVE * kD;
            movementY = (int)(PY + IY + DY);
            lastDifferenceY = differenceY;

            Console.WriteLine("PX:" + PX + " IX: " + IX + " DX: " + DX);
            Console.WriteLine("PY:" + PY + " IY: " + IY + " DY: " + DY);

            //update mouse position
            Cursor.Position = new Point(Cursor.Position.X + movementX, Cursor.Position.Y + movementY);
            return isMoving;

        }

        public void DoLeftClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
            form.SetStatusZ("Clic Esquerre");
        }

        public void DoRightClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
            form.SetStatusZ("Clic Dret");
        }
    }
}
