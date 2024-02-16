using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using arcade;

public class MyGame : Game {
    public MyGame() : base(1366, 768, false)     // Create a window that's 800x600 and NOT fullscreen
	{
        Level level = new Level();
		Conductor conductor = new Conductor();

        AddChild(level);
		AddChild(conductor);

        Console.WriteLine("My game initialized");
	}

	// For every game object, Update is called every frame, by the engine:
	void Update()
	{
        
    }

	static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}