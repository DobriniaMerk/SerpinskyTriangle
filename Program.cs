using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SerpinskyTriangle;


VideoMode vm = new VideoMode(800, 600);
RenderWindow rw = new RenderWindow(vm, "Fractal");
Fractal fractal = new Fractal(new Vector2f(400, 300));

bool lmb = false;
Vector2f mDisp = new Vector2f(0, 0);
float zoom = 1f, zoomAmount = 0.3f;


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
    fractal.SimpleDraw(7, zoom, rw);
}


void OnClose(object sender, EventArgs e)
{
    rw.Close();
}


void OnMouseMove(object sender, MouseMoveEventArgs e)
{
    Vector2f mpos = new Vector2f(e.X, e.Y);

    if (Mouse.IsButtonPressed(Mouse.Button.Left))
    {
        if (!lmb)
        {
            lmb = true;
            mDisp = fractal.position - mpos;
        }
        fractal.position = mpos + mDisp;
    }
    else
        lmb = false;
}


void OnScroll(object sender, MouseWheelScrollEventArgs e)
{
    zoom += e.Delta * zoomAmount;
}