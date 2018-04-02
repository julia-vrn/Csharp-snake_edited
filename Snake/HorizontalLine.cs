using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class HorizontalLine : Figure //класс горизонтальная линия содержит в себе все элементы класса figure
    {
        public HorizontalLine(int xLeft, int xRight, int y, char sym)
        {
            pList = new List<Point>();

            //передаем координаты в конструктор
            for(int x = xLeft; x <=xRight; x++)
            {
                Point p = new Point(x, y, sym);
                pList.Add(p);

            }

            
        }

    }
}
