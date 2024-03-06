namespace ConsoleApp1;

public class PlayField
{
    private int height;
    private int width;
    private char[,] field;

    public PlayField(int height, int width)
    {
        this.height = height;
        this.width = width;
        field = new char[height, width];
    }

    //ohraniceni pole, mezerniky dovnitr pole
    public void InicalitonOfField()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (i == 0 || i == width - 1 || j == 0 || j == height - 1)
                {
                    field[i, j] = 'O';
                }
                else
                {
                    field[i, j] = ' ';
                }
            }
        }
    }
    
    

    public void ClearField()
    {
        InicalitonOfField();
    }
    public void RenderGame(int width, int height, Snake snake, Fruit fruit)
    {
        // Create the playing field
        char[,] gameField = new char[height, width];

        // Fill the playing field with empty spaces
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 0 || i == width - 1 || j == 0 || j == height - 1)
                {
                    gameField[i, j] = 'O';
                }
                else
                {
                    gameField[i, j] = ' ';
                }
            }
        }

        // Add the snake to the playing field
        Queue<Tuple<int, int>> snakeCoordinates = snake.GetCoordinates();
        foreach (var segment in snakeCoordinates)
        {
            int x = segment.Item1;
            int y = segment.Item2;
            gameField[y, x] = '#'; // '#' represents the snake's body
        }
        
        // Add the fruit to the playing field if it exists
        if (fruit != null)
        {
            gameField[fruit.Y, fruit.X] = 'X'; // 'X' represents the fruit
        }

        // Render the playing field
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(gameField[i, j]);
            }
            Console.WriteLine();
        }
        
    }
}