namespace ConsoleApp1;

public enum Direction 
{
    Left,
    Right,
    Up,
    Down
}


public class Snake
{
    private int length;
    public Direction direction;
    
    public static int[] coordinates = {5,5}; 
    //public Queue<int[,]> coordinates;

    public Snake(int length)
    {
        this.length = 1;
        this.direction = Direction.Up; 
        //coordinates = new Queue<int[,]>();
    }
    
    
    public int GetLength()
    {
        return length;
    }

    public int ExtendLenght()
    {
        length++;
        return length;
    }

    public void ChangeDirection(ConsoleKeyInfo keyInput)
    {
        //input a jestli to je legal
        switch (keyInput.Key)
        {
            case ConsoleKey.LeftArrow:
                if (direction != Direction.Right)
                    direction = Direction.Left;
                break;
            case ConsoleKey.RightArrow:
                if (direction != Direction.Left)
                    direction = Direction.Right;
                break;
            case ConsoleKey.UpArrow:
                if (direction != Direction.Down)
                    direction = Direction.Up;
                break;
            case ConsoleKey.DownArrow:
                if (direction != Direction.Up)
                    direction = Direction.Down;
                break;
        }
    }

    
    
    

}
