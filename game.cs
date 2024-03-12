using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class game
    {
        public struct cell
        {
            public int number;
            public bool fixe;

        } 
        public int[,] su_in; /*= new int[,]{
                 {0,0,7   ,0,0,0    ,4,0,6},
                 {8,0,0   ,4,0,0    ,1,7,0},
                 {0,0,0   ,3,0,0    ,9,0,5},

                 {0,0,0   ,7,0,5    ,0,0,8},
                 {0,0,0   ,0,0,0    ,0,0,0},
                 {4,0,0   ,2,0,8    ,0,0,0},

                 {7,0,4   ,0,0,3    ,0,0,0},
                 {0,5,2   ,0,0,1    ,0,0,9},
                 {1,0,8   ,0,0,0    ,6,0,0}   
                };*/
        
        public int[,] su_out;/*= new  int[,] {


                 {5,3,7   ,9,1,2    ,4,8,6},
                 {8,2,9   ,4,5,6    ,1,7,3},
                 {6,4,1   ,3,8,7    ,9,2,5},

                 {9,1,3   ,7,4,5    ,2,6,8},
                 {2,8,6   ,1,3,9    ,7,5,4},
                 {4,7,5   ,2,6,8    ,3,9,1},

                 {7,6,4   ,8,9,3    ,5,1,2},
                 {3,5,2   ,6,7,1    ,8,4,9},
                 {1,9,8   ,5,2,4    ,6,3,7}
                };*/
        public cell[,] cells  ;
        
        public virtual int[,] getArray()
        {
            
            return null;
        }

       /* bool box_validate(int i, int j)
        {
            int k = j, n = i;
            int temp_i = i, temp_j = j, temp_k = k, temp_n = n;
            for (i = temp_i; i < temp_i + 3; i++)
                for (j = temp_j; j < temp_j + 3; j++)
                    for (k = temp_k; k < temp_k + 3; k++)
                    {
                        if ( k != j && su_in[i,j] != 0)
                        {
                            if (su_in[i,j] == su_in[i,k])
                                return false;

                            for (n = temp_n; n < temp_n + 3; n++)
                            {
                                if ( su_in[i,j] != 0)
                                    if (k == j && n == i)
                                        return false;
                                    else
                                        if (su_in[i,j] == su_in[n,k])
                                            return false;

                            }
                        }
                    }
            return true;

        }*/
        /* public virtual bool check()
        {
            int i, j, k, n, count = 0;
            //..........................row validation
            for(i=0; i<9; i++)
                for(j=0; j<9; j++)
                    for (k = 0; k < 9; k++)
                    {
                        if ( k != j && su_in[i,j] != 0)
                        {
                            if (su_in[i,j] == su_in[i,k])
                                return false;
                        }
                        else if(k!=j && su_in[i,j] == 0)
                              return false;

                    }
            //..................................colume validation
            for (i = 0; i < 9; i++)
                for (j = 0; j < 9; j++)
                    for (k = 0; k < 9; k++)
                    {
                        if (k != j && su_in[i, j] != 0)
                        {
                            if (su_in[j, i] == su_in[k, i])
                                return false;
                        }
                        else if (k != j && su_in[i, j] == 0)
                            return false;

                    }
            //..................................each box validating
            for (i = 0; i <= 6; i = i + 3)
                for (j = 0; j <= 6; j = j + 3)
                {
                    if (!box_validate(i, j) )
                        return false;
                }
            return true;
            /*
              for(i=0; i<9; i++)
        for(j=0; j<9; j++)
            for(k=0;k<9;k++)
                {
                    if(sudoku==1 && k!=j && su_in[i][j]!=0)
                       {
                        if(su_in[i][j]==su_in[i][k])
                        return 1;
                       }
                     else if(sudoku==2 && k!=j )
                       {
                        if(su_out[i][j]==su_out[i][k])
                        return 1;
                       }  


                }
//..................................colume validation
    for(i=0;  i<9;  i++)
        for(j=0;  j<9;  j++)
            for(k=0;  k<9;  k++)
                {
                    if(sudoku==1 && k!=j && su_in[j][i]!=0)
                       {
                        if(su_in[j][i]==su_in[k][i])
                        return 1;
                       }
                     else if(sudoku==2 && k!=i )
                       {
                        if(su_out[j][i]==su_out[j][k])

                        return 1;
                       }    
                }
    // each box validating.......................
    for(i=0;  i<=6;  i=i+3)
        for(j=0; j<=6; j=j+3)
        {
            if(box_validate(i,j,sudoku)==1)
            return 1;
        }

    // sum validation for output....

    if(sudoku==2)
    {
        for(i=0; i<9; i++)
        for(j=0; j<9; j++)
            count=count+su_out[i][j];

    if(count!=405) return 1;
    }


        return 0; 
             

        }*/
        public virtual bool check()
        {
            for(int i=0; i<9; i++)
                for(int j=0; j<9; j++)
                {
                    if (!checkrow(i, j))
                        return false;
                }
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (!checkcolumn(i, j))
                        return false;
                }
            for (int i = 0; i < 9; i++)
                for (int j = 0; j < 9; j++)
                {
                    if (!checksquare(i, j))
                        return false;
                }
            return true;
        }

       

        bool checkrow(int row, int column)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != column)
                {
                    if (su_in[row, i] == su_in[row, column] )
                    {
                        return false;
                    }
                }
            }

            return true;

        }
        bool checkcolumn(int row, int column)
        {

            for (int i = 0; i < 9; i++)
            {
                if (i != row)
                {
                    if (su_in[i,column] == su_in[row,column])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        bool checksquare(int row, int column)
        {
            int vsquare = row / 3;
            int hsquare = column / 3;

            for (int i = vsquare * 3; i < (vsquare * 3 + 3); i++)
            {
                for (int j = hsquare * 3; j < (hsquare * 3 + 3); j++)
                {
                    if (!(i == row && j == column))
                    {
                        if (su_in[row, column] == su_in[i,j])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public virtual bool solve(int row, int column)
        {
            int  n ;
	       
            while (cells[row,column].fixe == true)
                    {
		            column++;
		
		            if(column > 8){
			            column = 0;
			            row++;
		            }
		            if (row > 8){
			            return true;
		            }
	                }
            for ( n = 1; n < 10; n++)
            {
                int nextrow, nextcolumn;

                su_in[row, column] = n;

                if (checkcolumn(row, column) && checkrow(row, column) && checksquare(row, column))
                {
                    nextrow = row;
                    nextcolumn = column;

                    nextcolumn++;
                    if (nextcolumn > 8)
                    {
                        nextcolumn = 0;
                        nextrow++;
                    }
                    if (nextcolumn == 0 && nextrow == 9)
                    {
                        return true;
                    }
                    if (solve(nextrow, nextcolumn))
                    {
                        return true;
                    }
                }
            }
            su_in[row,column] = 0;

            return false;
        }
    }
}
