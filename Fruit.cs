namespace ConsoleApp1;

public class Fruit
{
    public int X { get; private set; } // X-coordinate of the fruit
    public int Y { get; private set; } // Y-coordinate of the fruit

    // Constructor to initialize the fruit's position
    public Fruit(int x, int y)
    {
        X = x;
        Y = y;
    }
    
}