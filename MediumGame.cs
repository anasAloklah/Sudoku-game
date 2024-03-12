using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class MediumGame:game
    {
        public MediumGame()
        {
          
            su_in = new int[,]{
                 {0,5,0   ,0,0,0    ,0,4,0},
                 {8,0,0   ,4,0,3    ,1,0,0},
                 {4,0,1   ,0,0,0    ,0,8,6},

                 {0,1,0   ,7,0,0    ,0,9,0},
                 {0,0,8   ,0,3,0    ,2,0,0},
                 {0,9,0   ,0,0,5    ,0,1,0},

                 {9,7,0   ,0,0,0    ,8,0,1},
                 {0,0,4   ,9,0,2    ,0,0,5},
                 {0,8,0   ,0,0,0    ,0,3,0}   
                };
            cells = new cell[9,9] ;
            for (int i=0;i<9;i++)
                for (int j=0;j<9;j++)
                {
                    if(su_in[i,j]!=0)
                    {
                        cells[i,j].number=su_in[i, j];
                        cells[i,j].fixe=true;
                    }
                    else
                    {
                        cells[i, j].number = 0;
                        cells[i, j].fixe = false;
                    }
                }


        
        }
        public override int[,] getArray()
        {
            return su_in;
        }
    }
}
