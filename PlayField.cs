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
    

    public void DrawField()
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Console.Write(field[i,j]);
            }
            Console.WriteLine();
        }
    }

    public void ClearField()
    {
        InicalitonOfField();
    }
    
}