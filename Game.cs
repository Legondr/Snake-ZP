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

    public void PlayGame()
    {
        Fruit fruit = null;
        bool ateFruit = false;
        while (alive)
        {
            Console.Clear();
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey(true);
                snake.ChangeDirection(keyInput);
            }
            snake.Move();
            
            field.RenderGame(15,15,snake, fruit);
            
            System.Threading.Thread.Sleep(500);
            
        }
        
    }
    
    
}