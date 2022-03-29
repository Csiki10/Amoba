using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba
{
    public class Logic : IGameModel
    {
        int selectCount;
        static Random rnd = new Random();

        public enum Item
        {
            x, o, e
        }

        public Item[,] GameMatrix { get; set; }

        public Logic()
        {
            GameMatrix = new Item[3,3];
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    GameMatrix[i, j] = Item.e;
                }
            }
            selectCount = 0;
        }

        /*
        public void CellChange(Item item, int x,int y)
        {
            if (IsEmptyCell(x,y))
            {
                GameMatrix[x, y] = item;
            }                    
        }*/

        private bool IsEmptyCell(int x, int y)
        {
            if (GameMatrix[x,y] == Item.e)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool IsGameEnd()
        {
            int dbsorX = 0;
            int dbsorO = 0;

            int dboszlopX = 0;
            int dboszlopO = 0;

            int i = 0;
            int j = 0;

            bool x1 = false;           

            while (i < GameMatrix.GetLength(1) && (dboszlopO < 3 || dboszlopX < 3))
            {
                while (j < GameMatrix.GetLength(0) && (dboszlopO < 3 || dboszlopX < 3))
                {
                    if (j % 3 == 0)
                    {
                        dbsorO = 0;
                        dbsorX = 0;
                    }
                    if (GameMatrix[i, j] == Item.x)
                    {
                        dbsorX++;
                    }
                    else if (GameMatrix[i, j] == Item.o)
                    {
                        dbsorO++;
                    }
                    j++;
                }

                i++;
            }

            while (i < GameMatrix.GetLength(0) && (dboszlopO < 3 || dboszlopX < 3))
            {
                while (j < GameMatrix.GetLength(1) && (dboszlopO < 3 || dboszlopX < 3))
                {
                    if (j % 3 == 0)
                    {
                        dbsorO = 0;
                        dbsorX = 0;
                    }
                    if (GameMatrix[i, j] == Item.x)
                    {
                        dbsorX++;
                    }
                    else if (GameMatrix[i, j] == Item.o)
                    {
                        dbsorO++;
                    }
                    j++;
                }
                i++;
            }

            if ((GameMatrix[0,0] == Item.x && GameMatrix[1, 1] == Item.x && GameMatrix[2, 2] == Item.x) 
                || (GameMatrix[0, 2] == Item.x && GameMatrix[1, 1] == Item.x && GameMatrix[2, 0] == Item.x)
                || (GameMatrix[0, 2] == Item.o && GameMatrix[1, 1] == Item.o && GameMatrix[2, 0] == Item.o)
                || (GameMatrix[0, 0] == Item.o && GameMatrix[1, 1] == Item.o && GameMatrix[2, 2] == Item.o))
            {
                x1 = true;
            }


            if (dboszlopX == 3 || dboszlopO == 3 || dbsorO == 3 || dbsorX == 3 || x1 == true)
            {
                return true;
            }
            else
            {
                return false;
            }

            /*
            for (int i = 0; i < GameMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(1); j++)
                {
                    // egy sorban nézi
                    if (j % 3 == 0)
                    {
                        dbsorO = 0;
                        dbsorX = 0;
                    }
                    if (GameMatrix[i, j] == Item.x)
                    {
                        dbsorX++;
                    }
                    else if (GameMatrix[i, j] == Item.o)
                    {
                        dbsorO++;


                    }
                }               
            }
          
            for (int i = 0; i < GameMatrix.GetLength(1); i++)
            {
                for (int j = 0; j < GameMatrix.GetLength(0); j++)
                {
                    // egy sorban nézi
                    if (j % 3 == 0)
                    {
                        dbsorO = 0;
                        dbsorX = 0;
                    }
                    if (GameMatrix[i, j] == Item.x)
                    {
                        dbsorX++;
                    }
                    else if (GameMatrix[i, j] == Item.o)
                    {
                        dbsorO++;
                    }
                }
            }
            */
        }

        public void AISelect()
        {
            int x = rnd.Next(0, 3);
            int y = rnd.Next(0, 3);

            if (IsEmptyCell(x,y))
            {
                GameMatrix[x, y] = Item.o;
            }
            selectCount++;
        }

        public void PlayerSelect(int x, int y)
        {
            if (IsEmptyCell(x, y))
            {
                GameMatrix[x, y] = Item.x;
            }
            selectCount++;
            // meg kene hivni a gépeet.
           
        }
    }
}