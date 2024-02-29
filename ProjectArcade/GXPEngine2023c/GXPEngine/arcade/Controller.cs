using GXPEngine;
using System;
using System.IO.Ports;

namespace arcade
{
    internal class Controller : GameObject
    {
        
        SerialPort port = new SerialPort();
        char[] seperators = new char[] { ',', '\r', '\n' };
        string[] inputs;
        int[] values = new int[4];
        public int B1;
        public int B2;
        public int B3;
        public int DiskRotation;

        public static Controller main;

        public Controller() 
        {
            string[] value = SerialPort.GetPortNames();       //For checking which port the arduino is in.
            main = this;

            port.PortName = value[0];
            port.BaudRate = 57600;
            port.RtsEnable = true;
            port.DtrEnable = true;
            port.Open();
        }


        void Update()
        {
            while (port.BytesToRead > 1)
            {
                string a = port.ReadLine();
                inputs = a.Split(seperators, StringSplitOptions.RemoveEmptyEntries);
                //Console.WriteLine(inputs.Length);
                if (a != "")
                {
                    bool fail = false;
                    for (int i = 0; i < inputs.Length; i++)
                    {
                        if (i < values.Length)
                        {
                            if (int.TryParse(inputs[i], out int intValue))
                            {
                                values[i] = intValue;
                                //Console.WriteLine("failed");
                            }
                            fail = true;
                            if (values.Length == 4 || values.Length == 4 * 2)
                            {
                                fail = false;
                                //Console.WriteLine("not failed");
                            }
                        }
                    }
                    if (!fail)
                    {
                        //Console.WriteLine(values[0] + ", " + values[1] + ", " + values[2] + ", " + values[3]);
                        //Console.WriteLine("goed");
                        DiskRotation = values[0];
                        B1 = values[1];
                        B2 = values[2];
                        B3 = values[3];
                    }
                }
                else
                {
                    //Console.WriteLine("empty");
                }
            }
        }
    }
}

