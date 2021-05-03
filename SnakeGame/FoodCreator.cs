using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGame
{
    class FoodCreator
    {
        int mapWidth;
        int mapHight;
        char sym;

        Random random = new Random();
        public FoodCreator(int mapWidth, int mapHight, char sym)
        {
            this.mapWidth = mapWidth;
            this.mapHight = mapHight;
            this.sym = sym;
        }
        public Point CreateFood()
        {
            int x = random.Next(4, mapWidth - 4);
            int y = random.Next(4, mapHight - 4);
            
            return new Point(x, y, sym);

        }

    }
}
