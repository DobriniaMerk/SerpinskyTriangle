using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SerpinskyTriangle;


VideoMode vm = new VideoMode(800, 600);
RenderWindow rw = new RenderWindow(vm, "Fractal");
Fractal fractal = new Fractal();

rw.Closed += OnClose;

while (rw.IsOpen)
{
    rw.DispatchEvents();
    rw.Clear();
    Update();
    rw.Display();
}

void Update()
{
    fractal.SimpleDraw(3, rw);
}

void OnClose(object sender, EventArgs e)
{
    rw.Close();
}