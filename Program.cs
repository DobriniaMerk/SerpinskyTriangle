using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SerpinskyTriangle;


VideoMode vm = new VideoMode(800, 600);
RenderWindow rw = new RenderWindow(vm, "Fractal");
Fractal fractal = new Fractal();

bool lmb = false;
Vector2f t = new Vector2f(0, 0);
Vector2f mpos = t, oldMpos = t, camera = t;
float zoom = 1f, zoomAmount = 0.2f;


rw.Closed += OnClose;
rw.MouseMoved += OnMouseMove;
rw.MouseWheelScrolled += OnScroll;


while (rw.IsOpen)
{
    rw.DispatchEvents();
    rw.Clear();
    Update();
    rw.Display();
}


void Update()
{
    rw.SetView(new View(camera * -1, new Vector2f(800, 600) * zoom));
    fractal.SimpleDraw((int)(MathF.Log2(800 / zoom) - 2.5f), rw);
}


void OnClose(object sender, EventArgs e)
{
    rw.Close();
}


void OnMouseMove(object sender, MouseMoveEventArgs e)
{
    oldMpos = mpos;
    mpos = new Vector2f(e.X, e.Y);

    if (Mouse.IsButtonPressed(Mouse.Button.Left))
    {
        camera += (mpos - oldMpos) * zoom;
    }
}


void OnScroll(object sender, MouseWheelScrollEventArgs e)
{
    zoom -= e.Delta * zoomAmount * zoom;
    camera += (camera + new Vector2f(400, 300) - new Vector2f(e.X, e.Y)) * (e.Delta * zoomAmount * zoom);  // not working
}