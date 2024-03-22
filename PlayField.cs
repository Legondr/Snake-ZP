namespace ConsoleApp1;

public class PlayField
{
    public int height;
    public int width;
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
        PlaceFruit();
    }
    
    

    public void ClearField()
    {
        InicalitonOfField();
    }

    public void PlaceFruit()
    {
        Random random = new Random();
        int postionX, postionY;
        
        do
        {
             postionX = random.Next(1,width-1);
             postionY = random.Next(1,height-1);
        } while (field[postionY, postionX] != ' ');

        field[postionY, postionX] = 'X';
        
    }

    public bool CheckEatFruit(int headX, int headY)
    {
        if (field[headY, headX] == 'X')
        {
            PlaceFruit();
            return true;
        }

        return false;
    }
    
    public void RenderGame(Snake snake)
    {
        var snakeHead = snake.coordinates.ElementAt(snake.coordinates.Count - 1);
        int x = snakeHead.Item1;
        int y = snakeHead.Item2;
        field[y, x] = '#'; // '#' represents the snake's body

        

        // Render the playing field
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                Console.Write(field[i, j]);
            }
            Console.WriteLine();
        }
        
    }

    public void RemoveTail(int tailX, int tailY)
    {
        field[tailY, tailX] = ' ';
    }
}