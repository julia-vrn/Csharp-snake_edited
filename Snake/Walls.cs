using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Walls
    {
        List<Figure> wallList;

        public Walls(int mapWidth, int mapHeight)
        {
            wallList = new List<Figure>();

            HorizontalLine upLine = new HorizontalLine(0, mapWidth - 2, 0, '*');
            HorizontalLine downLine = new HorizontalLine(0, mapWidth - 2, mapHeight - 1, '*');
            VerticalLine leftLine = new VerticalLine(0, mapHeight - 1, 0, '*');
            VerticalLine rightLine = new VerticalLine(0, mapHeight - 1, mapWidth - 2, '*');
           

            int[] yUp = new int[] {3, 4, 5, 6, 7};
          
            Random rnd = new Random();

            int obstYup;
            int obstX;
            obstYup = rnd.Next(5, 18);
            obstX = rnd.Next(8, 75);
            bool hasY = yUp.Contains(obstYup);
            

            int newY;
            do
            {
                newY = rnd.Next(2, 18);
            } while (hasY);

            obstYup = newY;

            
            VerticalLine verticalObstacle = new VerticalLine(obstYup, obstYup + 2, obstX, '%');

            int xTail = rnd.Next(3, 72);
            int[] yTail = new int[] { 2, 3, 4, 5, 6 };
            int obstYTail = rnd.Next(3, 21);
            bool hasYTail = yTail.Contains(obstYTail);

            int newYtail;
            do
            {
                newYtail = rnd.Next(3, 21);
            } while (hasYTail);

            obstYTail = newYtail;

            HorizontalLine horizontalObstacle = new HorizontalLine(xTail, xTail + 3, obstYTail, '%');
               
            wallList.Add(upLine);
            wallList.Add(downLine);
            wallList.Add(leftLine);
            wallList.Add(rightLine);
            wallList.Add(verticalObstacle);
            wallList.Add(horizontalObstacle);

        }

        internal bool IsHit(Figure figure)
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

        internal bool isHitFood(Point point)
        {
            foreach(var wall in wallList)
            {
                if (wall.IsHit(point)){
                    return true;

                }
                    
                
            }
            return false;
        }

        public void Draw()
        {
            foreach(var wall in wallList)
            {
                wall.Draw();
            }
        }
    }
    

}
