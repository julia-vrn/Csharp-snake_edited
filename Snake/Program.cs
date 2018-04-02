using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake

{
    
    class Program
    {
        

        public static void Main(string[] args)
        {
            Console.SetBufferSize(80, 25);

            int score = 0;
            Walls walls = new Walls(80, 25);
            walls.Draw();

            // Отрисовка точек			
            Point p = new Point(4, 5, '*');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();
            int speed = 500;

                    

            FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();

            while (walls.isHitFood(food))
            {
                
                food = foodCreator.CreateFood();
                
                break;
            }

            food.Draw();

           
            /*FoodCreator foodCreator = new FoodCreator(80, 25, '$');
            Point food = foodCreator.CreateFood();
            food.Draw();*/

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                {
                    break;
                }
                if (snake.Eat(food))
                {
                    food = foodCreator.CreateFood();
                    while (walls.isHitFood(food))
                    {

                        food = foodCreator.CreateFood();

                        break;
                    }

                    food.Draw();
                    //food = foodCreator.CreateFood();
                    //food.Draw();
                    score++;
                    speed = speed - 30;
                   
                   
                }
                else
                {
                    snake.Move();
                }

                System.Threading.Thread.Sleep(speed);
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey();
                    snake.HandleKey(key.Key);
                }
            }
            string str_score = Convert.ToString(score);
            WriteGameOver(str_score);
            Console.ReadLine();
        }


        static void WriteGameOver(string score)
        {
            int xOffset = 25;
            int yOffset = 8;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(xOffset, yOffset++);
            WriteText("============================", xOffset, yOffset++);
            WriteText("       GAME OVER            ", xOffset + 1, yOffset++);
            yOffset++;
            WriteText(" Вы набрали "+score+" очков ", xOffset + 2, yOffset++);
            WriteText("", xOffset + 1, yOffset++);
            WriteText("============================", xOffset, yOffset++);
        }

        static void WriteText(String text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }

    }
}
