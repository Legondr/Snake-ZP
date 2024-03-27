namespace ConsoleApp1;

public class Game
{
    private Snake snake;
    private PlayField field;
    private int score;
    private int tic;
    public bool alive;
    
    public Game()
    {
        this.snake = new Snake(3);
        this.field = new PlayField(15, 15);
        score = 0;
        tic = 0;
        alive = true;
    }

    public void StartGame()
    {
        Console.CursorVisible = false;
        field.InicalitonOfField();
        Snake snake = new Snake(1);
        
    }

    public void ClearConsoleBuffer()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey();
        }
            
    }

    public void PlayGame()
    {
        while (alive)
        {
            Console.Clear();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey(true);
                ClearConsoleBuffer();
                snake.ChangeDirection(keyInput);
            }
            alive = snake.Move(field);

            if (alive)
            {
                field.RenderGame(snake);
            }
            else
            {
                GameOver();
            }
            
            
            System.Threading.Thread.Sleep(300);
            
        }
        
    }

    public void GameOver()
    {
        Console.Clear();
        Console.WriteLine("Game over.");
        Console.ReadKey();
    }
    
}