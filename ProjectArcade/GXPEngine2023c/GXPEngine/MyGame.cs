using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using arcade;
using TiledMapParser;
using System.Runtime.Remoting.Messaging;

public class MyGame : Game {

    Player _player;
    public string Healthbar;

    public MyGame() : base(1366, 768, false)     // Create a window that's 800x600 and NOT fullscreen
	{
        EasyDraw canvas = new EasyDraw(1366, 768, false);

        Level level = new Level();

		AddChild(level);
        AddChild(canvas);

		_player = MyGame.main.FindObjectOfType<Player>();
        Healthbar = "Health: " + _player.health;

        canvas.TextSize(32);
        canvas.TextAlign(CenterMode.Min, CenterMode.Min);
        canvas.SetColor(0, 0, 0);
        canvas.Text(Healthbar, 10, 10);

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