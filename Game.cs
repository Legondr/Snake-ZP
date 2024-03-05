namespace ConsoleApp1;

public class Game
{
    private Snake snake;
    private PlayField field;
    private int score;
    private int tic;
    private bool alive;
    
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
        field.DrawField();
        
    }

    public void PlayGame()
    {
        while (alive)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey(true);
                snake.ChangeDirection(keyInput);
            }
        }
        
    }
    
    
}