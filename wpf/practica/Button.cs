using System.Drawing;

internal class Button
{
    public Size Size { get; internal set; }
    public Point Location { get; internal set; }
    public string Text { get; internal set; }
    public EventHandler Click { get; internal set; }
}