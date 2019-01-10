using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

        const double X_MOVE = 11;
        const double X_MIN = 41;
        const double X_MAX = 43;
        const double Y_MOVE = 15;
        const double Y_MIN = 40;
        const double Y_MAX = 42.7;
        const double Z_MIN = 47;
        const double Z_MAX = 54;
        const long CLICK_TIME = 500;

        Stopwatch clickTime = new Stopwatch();
        bool wasClicked = false;
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

        /*double lastX = 0;
        double lastY = 0;
        double lastZ = 0;*/


        private SerialPort port = new SerialPort("COM9", 9600, Parity.None, 8, StopBits.One);

        // Create the serial port with basic settings 
        public SerialPortManager()
        {
            Console.WriteLine("Incoming Data:");
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
                string[] components = s.Split(' ');

                double x = Double.Parse(components[1]);
                double y = Double.Parse(components[0]);
                double z = Double.Parse(components[2]);

                if (!isClick(z))
                {
                    moveMouse(x, y);
                }
            }
            catch (Exception)
            {

            }
        }

        private bool isClick(double z)
        {
            Console.WriteLine(z);

            if (z > Z_MAX && !wasClicked)
            {
                DoLeftClick();
                wasClicked = true;
                clickTime.Start();
            }

            if (z < Z_MIN && !wasClicked) {

                DoRightClick();
                wasClicked = true;
                clickTime.Start();
            }

            if (z >= Z_MIN && z <= Z_MAX)
            {
                if (clickTime.ElapsedMilliseconds > CLICK_TIME)
                {
                    wasClicked = false;
                    clickTime.Reset();
                }

                return false;
            }

            return wasClicked;
        }

        private void moveMouse(double x, double y)
        {
            int movementX = 0;
            int movementY = 0;
            double differenceX = 0.0;
            double differenceY = 0.0;

            // move to right;
            if (x < X_MIN) {
                differenceX = (X_MIN - x) / (X_MAX - X_MIN);
            }
            // move to left
            else if (x > X_MAX)
            {
                differenceX = (X_MAX - x) / (X_MAX - X_MIN);
            }
            // move to up;
            if (y < Y_MIN)
            {
                differenceY = (y - Y_MIN) / (Y_MAX - Y_MIN);
            }
            // move to down
            else if (y > Y_MAX)
            {
                differenceY = (y - Y_MAX) / (Y_MAX - Y_MIN);
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

            //Console.WriteLine("X:" + movementX + "Y: " + movementY);
            Cursor.Position = new Point(Cursor.Position.X + movementX, Cursor.Position.Y + movementY);

        }
        
        public void DoLeftClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        public void DoRightClick()
        {
            //Call the imported function with the cursor's current position
            uint X = (uint)Cursor.Position.X;
            uint Y = (uint)Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_RIGHTDOWN | MOUSEEVENTF_RIGHTUP, X, Y, 0, 0);
        }
    }
}
