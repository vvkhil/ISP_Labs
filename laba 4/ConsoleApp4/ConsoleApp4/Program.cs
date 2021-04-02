using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ConsoleApp4
{
    class dllWin32
    {
        [DllImport("User32.dll")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("User32.dll")]
        public static extern int MessageBox(IntPtr hwnd, String text, String Caption, int options);
    }
    class MyDll
    {
        [DllImport("Dll2.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern float Addition(float a, float b);

        [DllImport("Dll2.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern float Difference(float a, float b);

        [DllImport("Dll2.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern float Multiplication(float a, float b);

        [DllImport("Dll2.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern float Divide(float a, float b);
    }

    class Program
    {
        static void Main(string[] args)
        {   
            IntPtr ptrDesktop = dllWin32.GetDC(IntPtr.Zero);

            Graphics graf = Graphics.FromHdc(ptrDesktop);

            Console.WriteLine("1 - Inscription");
            Console.WriteLine("2 - Message box");
            Console.WriteLine("3 - Bezier curve");
            Console.WriteLine("4 - My dll");
            Console.Write("Choose what you want to do:");
            string choise = Console.ReadLine();
            switch (choise)
            { 
                case "1":
                    SolidBrush firstBrush = new SolidBrush(Color.Red);

                    String drawString = "Test inscription";

                    Font drawFont = new Font("Calibri", 100);

                    StringFormat myFormat = new StringFormat();
                    myFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;

                    Point pnt = new Point(1400, 50);

                    for (int i = 0; i < 100; i++)
                    {
                        graf.DrawString(drawString, drawFont, firstBrush, pnt, myFormat);
                    }
                    break;
                case "2":
                    dllWin32.MessageBox(IntPtr.Zero, "Test", "My message", 0);
                    break;
                case "3":
                    SolidBrush secondBrush = new SolidBrush(Color.White);

                    Point pt1 = new Point(1100, 50);
                    Point pt2 = new Point(400, 150);
                    Point pt3 = new Point(700, 250);
                    Point pt4 = new Point(1200, 350);

                    Pen pen = new Pen(secondBrush);

                    for (int i = 0; i < 100; i++)
                    {
                        graf.DrawBezier(pen, pt1, pt2, pt3, pt4);
                    }
                    break;
                case "4":
                    float result = MyDll.Addition(3, 2);
                    Console.WriteLine($"Addition:{result}");
                    result = MyDll.Difference(7, 2);
                    Console.WriteLine($"Difference:{result}");
                    result = MyDll.Multiplication(4, 2);
                    Console.WriteLine($"Multiplication:{result}");
                    result = MyDll.Divide(3, 2);
                    Console.WriteLine($"Divide:{result}");
                    break;
                default:
                    Console.WriteLine("Incorrect input! Please try again.");
                    break;

            }
        }
    }
}

