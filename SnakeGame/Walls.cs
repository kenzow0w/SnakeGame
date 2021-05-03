using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class Walls
    {
        List<Figure> wallList;

        public Walls (int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontLine HighLine = new HorizontLine(1, mapWidth - 1, 1, '+');
            HorizontLine DownLine = new HorizontLine(1, mapWidth - 1, mapHeight-1, '+');
            VerticalLine LeftLine = new VerticalLine(1, mapHeight-1, 1, '+');
            VerticalLine RightLine = new VerticalLine(1, mapHeight-1, mapWidth - 1, '+');

            wallList.Add(HighLine);
            wallList.Add(DownLine);
            wallList.Add(LeftLine);
            wallList.Add(RightLine);
        }

        internal bool IsHit (Figure figure)
        {
            foreach (var wall in wallList)
            {
                if (wall.IsHit(figure))
                {
                    return true;
                    

                }
                
            }
            return false;

        }



        public void Draw()
        {
            foreach ( var wall in wallList)
            {
                wall.Drow();

            }

        }
        

    }
}
