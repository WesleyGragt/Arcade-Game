using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using arcade;
using System.IO.Ports;

public class MyGame : Game {
    public MyGame() : base(1334, 768, false, true)     // Create a window that's 800x600 and NOT fullscreen
	{
        //Controller controller = new Controller();
        //AddChild(controller);

        targetFps = 100;

		SceneHandler sceneHandler = new SceneHandler();	
		AddChild(sceneHandler);
       
<<<<<<< Updated upstream
        Console.WriteLine("My game initialized");
        Console.WriteLine(targetFps);

=======
        Console.WriteLine("My game initialized");
>>>>>>> Stashed changes
    }

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
<<<<<<< Updated upstream
        Console.WriteLine(currentFps);
    }

	static void Main()                          // Main() is the first method that's called when the program is run
	{
        /*string[] value = SerialPort.GetPortNames();       //For checking which port the arduino is in.
            for (int i = 0; i < value.Length; i++)
            {
            Console.WriteLine(value[i]);
            }*/

        /*SerialPort port = new SerialPort();
        port.PortName = "COM7";
        port.BaudRate = 9600;
        port.RtsEnable = true;
        port.DtrEnable = true;
        port.Open();
        
        //string line = port.ReadLine(); // read separated values
        string line = port.ReadExisting(); // when using characters
        
        while (true)
        {
            if (line != "")
            {
                Console.WriteLine("Read from port: " + line);
            }
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey();
                port.Write(key.KeyChar.ToString());  // writing a string to Arduino
            }
        }*/

=======

	}

    static void Main()                          // Main() is the first method that's called when the program is run
	{
>>>>>>> Stashed changes
        new MyGame().Start();                   // Create a "MyGame" and start it
	}
}