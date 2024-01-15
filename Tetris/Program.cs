using Tetris;
//Init Method {

int mapWidth = 30;
int mapHeight = 25;
int[,] map = new int[mapHeight, mapWidth];
Figure currentFigure = new Figure(4,13,0);
Random random = new Random();
ConsoleKey key = new ConsoleKey();


for (int i = 0; i < mapHeight; i++)
{
    for (int j = 0; j < mapWidth; j++)
    {
        map[i,j] = 0;
    }
}
// }
while (true)
{

    while (!Console.KeyAvailable)
    {
        ClearFigure();
        if (!Collision())
        {
            switch (key)
            {
                case ConsoleKey.A:
                    currentFigure.MoveLeft();
                    key = ConsoleKey.Spacebar;
                    break;
                case ConsoleKey.D:
                    currentFigure.MoveRight();
                    key = ConsoleKey.Spacebar;
                    break;
            }
            currentFigure.MoveDown();
        }
        else
        {
            SynchFigure();
            currentFigure = new Figure(random.Next(1, 5), 15, 0);
        }
        SynchFigure();
        PrintMap();
        Thread.Sleep(100);
    }
    key = Console.ReadKey(true).Key;
    
}

void PrintMap()
{
        Console.SetCursorPosition(0, 0);
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                if (map[i, j] == 0) Console.Write('.');

                if (map[i, j] == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write('#');
                    Console.ResetColor();
                }
                if (map[i, j] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write('@');
                    Console.ResetColor();
                }
                if (map[i, j] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('[');
                    Console.Write(']');
                    Console.ResetColor();
                }
                if (map[i, j] == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write('%');
                    Console.ResetColor();
                }
                if (map[i, j] == 5)
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write('M');
                    Console.ResetColor();
                }
            }
            Console.WriteLine();
        }
}

void SynchFigure()
{
    for (int i = currentFigure.figure_y ;i < currentFigure.figure_y + Figure.figure_width; i++)
    {
        for (int j = currentFigure.figure_x;j < currentFigure.figure_x + Figure.figure_width; j++)
        {
            if (currentFigure.matrix[i - currentFigure.figure_y, j - currentFigure.figure_x] != 0) map[i, j] = currentFigure.matrix[i - currentFigure.figure_y, j - currentFigure.figure_x];
        }
    }
}

void ClearFigure()
{
    for (int i = currentFigure.figure_y; i < currentFigure.figure_y + Figure.figure_width; i++)
    {
        for (int j = currentFigure.figure_x; j < currentFigure.figure_x + Figure.figure_width; j++)
        {
            if (currentFigure.matrix[i - currentFigure.figure_y, j - currentFigure.figure_x] != 0) map[i, j] = 0;
        }
    }
}

bool Collision()
{
    for (int i = currentFigure.figure_y + Figure.figure_width - 1; i >= currentFigure.figure_y; i--)
    {
        for (int j = currentFigure.figure_x; j < currentFigure.figure_x + Figure.figure_width; j++)
        {
            if (currentFigure.matrix[i - currentFigure.figure_y, j - currentFigure.figure_x] != 0)
            {
                if (i + 1 == 25) return true;
                if (map[i + 1, j] != 0) return true;
            }
        }
    }
    return false;
}

