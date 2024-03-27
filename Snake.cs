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
    public Queue<Tuple<int, int>> coordinates;


    public Snake(int length)
    {
        this.length = 1;
        this.direction = Direction.Up;
        this.coordinates = new Queue<Tuple<int, int>>();
        // Initialize the snake with a single segment at position (5, 5)
        this.coordinates.Enqueue(new Tuple<int, int>(5, 5));
    }


    public int GetLength()
    {
        return length;
    }

    public int ExtendLenght()
    {
        length++;
        coordinates.Enqueue(coordinates.Peek());
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

    public bool Move(PlayField field)
    {
        // Move the snake according to its direction
        
        int headX = coordinates.Peek().Item1;
        int headY = coordinates.Peek().Item2;

        switch (direction)
        {
            case Direction.Left:
                headX--;
                break;
            case Direction.Right:
                headX++;
                break;
            case Direction.Up:
                headY--;
                break;
            case Direction.Down:
                headY++;
                break;
        }

        
        
        
        // Enqueue the new head position
        coordinates.Enqueue(new Tuple<int, int>(headX, headY));

        /*
        // Remove the tail segment if the snake has grown beyond its length
        if (coordinates.Count > length)
        {
            var tail = coordinates.Dequeue();
            int tailX = tail.Item1;
            int tailY = tail.Item2;
            
            field.RemoveTail(tailX,tailY);
            
        }
        */
        
        // Check collision with walls
        if (headX < 0 || headX >= field.width ||
            headY < 0 || headY >= field.height)
        {
            return false;
        }
        
        
        // Check collision with itself
        for (int i = coordinates.Count - 2; i >= 0; i--)
        {
            var segment = coordinates.ElementAt(i);
            if (segment.Item1 == headX && segment.Item2 == headY)
            {
                // Collision with itself, handle game over
                return false;
            }
        }

        if (field.CheckEatFruit(headX, headY))
        {
            ExtendLenght();
        }
        else
        {
            // If the snake didn't eat a fruit, dequeue the tail
            var tail = coordinates.Dequeue();
            int tailX = tail.Item1;
            int tailY = tail.Item2;
        
            // Tell the field to remove the tail
            field.RemoveTail(tailX, tailY);
        }
        
        return true;
    }

    
   
}

