using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Snake : Figure
    {
        Direction direction;
        //int Counter { get; set; }

        public Snake(Point tail, int length, Direction _direction)
        {
            
            direction = _direction;
            pList = new List<Point>();
            //Counter = 0;
            for (int i = 0; i < length; i++)
            {
                
                Point p = new Point(tail);
                p.Move(i, direction);
                pList.Add(p);
            }
        }

        public void Move()
        {
            Point tail = pList.First();
            pList.Remove(tail);
            Point head = GetNextPoint();
            pList.Add(head);
            var black = ConsoleColor.Black;
            var gray = ConsoleColor.Gray;
            var darkGray = ConsoleColor.DarkGray;

            tail.Clear();
           
            Random rnd = new Random();
            do
            {
                Console.ForegroundColor = (ConsoleColor)rnd.Next(0, 16);
            } while (Console.ForegroundColor == black|| Console.ForegroundColor == gray || Console.ForegroundColor == darkGray);

            Console.ForegroundColor = Console.ForegroundColor;
          
            
            head.Draw();
        }

        public Point GetNextPoint()
        {
            Point head = pList.Last();
            Point nextPoint = new Point(head);
            nextPoint.Move(1, direction);
            return nextPoint;
        }

        public bool IsHitTail()
        {
            var head = pList.Last();
            for (int i = 0; i < pList.Count - 2; i++)
            {
                if (head.IsHit(pList[i]))
                    return true;
            }
            return false;
        }

        public void HandleKey(ConsoleKey key)
        {
            if (key == ConsoleKey.LeftArrow)
                direction = Direction.LEFT;
            else if (key == ConsoleKey.RightArrow)
                direction = Direction.RIGHT;
            else if (key == ConsoleKey.DownArrow)
                direction = Direction.DOWN;
            else if (key == ConsoleKey.UpArrow)
                direction = Direction.UP;
        }

        public bool Eat(Point food)
        {
            Point head = GetNextPoint();
            if (head.IsHit(food))
            {
                //Counter++;
                food.sym = head.sym;
                pList.Add(food);
                

                return true;
            }
            else
                return false;
        }
    }
}