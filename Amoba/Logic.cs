using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amoba
{
    public class Logic : IGameModel
    {
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


        }

        public void StateChange(Item item, int x,int y)
        {
            GameMatrix[x, y] = item;
        }



    }
}