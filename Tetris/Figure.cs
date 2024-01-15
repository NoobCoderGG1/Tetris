using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    internal class Figure
    {
        public int[,] matrix;
        public int figure_x;
        public int figure_y;
        public const int figure_width = 3;

        public Figure(int selectedFigure, int x, int y) 
        { 
            figure_x = x;
            figure_y = y;

            switch (selectedFigure)
            {
                case 0:
                case 1:
                    matrix = new int[figure_width, figure_width]
                    {
                        {0,1,0 },
                        {0,1,0 },
                        {0,1,0 }
                    };
                    break;
                case 2:
                    matrix = new int[figure_width, figure_width]
                    {
                        { 0,2,0 },
                        { 0,2,2 },
                        { 0,0,2 }
                    };
                    break;
                case 3:
                    matrix = new int[figure_width, figure_width]
                    {
                        { 0,3,3 },
                        { 0,3,3 },
                        { 0,0,0 }
                    };
                    break;
                case 4:
                    matrix = new int[figure_width, figure_width]
                    {
                        { 0,0,0 },
                        { 0,4,0 },
                        { 4,4,4 }
                    };
                    break;
                case 5:
                    matrix = new int[figure_width, figure_width]
                    {
                        { 0,5,5 },
                        { 0,5,0 },
                        { 0,5,0 }
                    };
                    break;
            }
        }

        public void MoveLeft() => figure_x--;
        
        public void MoveRight() => figure_x++;
        
        public void MoveDown() => figure_y++;
    
    }
}
