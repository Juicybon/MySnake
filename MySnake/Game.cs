using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class Game
    {
        //размеры поля
        static int height = 30;
        static int width = 80;
        static Walls walls;

        static void Main()
        {
            Console.SetWindowSize(width + 1, height + 1);
            Console.SetBufferSize(width + 1, height + 1);
            Console.CursorVisible = false;
            walls = new Walls(width, height, '#');
            Snake mySnake = new Snake();
            ElementaryStage(mySnake);
            do { } while (true); //для проверки поля
        }

        /// <summary>
        /// Структура рисования символа по координатам
        /// </summary>
        struct Point
        {
            public int x { get; set; }
            public int y { get; set; }
            public char ch { get; set; }

            public static implicit operator Point((int, int, char) value) =>
                new Point { x = value.Item1, y = value.Item2, ch = value.Item3 };//посмотреть снова
            public void Draw()
            {
                DrawPoint(ch);
            }
            public void Clear()
            {
                DrawPoint(' ');
            }
            private void DrawPoint(char _ch)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(_ch);
            }
        }

        /// <summary>
        /// Стена
        /// </summary>
        class Walls
        {
            private char ch;
            private List<Point> wall = new List<Point>();


            public Walls(int x, int y, char ch)
            {
                this.ch = ch;
                DrawHorizontalWall(x, 0);
                DrawHorizontalWall(x + 1, y);
                DrawVerticalWall(0, y);
                DrawVerticalWall(x, y);
            }

            private void DrawHorizontalWall(int x, int y)
            {
                for (int i = 0; i < x; i++)
                {
                    Point p = (i, y, ch);
                    p.Draw();
                    wall.Add(p);
                }
            }
            private void DrawVerticalWall(int x, int y)
            {
                for (int i = 0; i < y; i++)
                {
                    Point p = (x, i, ch);
                    p.Draw();
                    wall.Add(p);
                }
            }
        }

        /// <summary>
        /// Змейка
        /// </summary>
        public class Snake
        {
            public bool isSnakeAlive;
            public int length = 3;
            public int x = 42, y = 15;
        }

        /// <summary>
        /// Начальное состояние игры
        /// </summary>
        public static void ElementaryStage(Snake mySnake)
        {
            mySnake.isSnakeAlive = true;
            Point mySnakeHead = (mySnake.x, mySnake.y, '@');
            mySnakeHead.Draw();
            List<Point> mySnakeBody = new List<Point>();
            for (int i = 1; i <= mySnake.length; i++)
            {
                mySnakeBody.Add((mySnake.x - i, mySnake.y, '0'));
            }
            foreach (Point row in mySnakeBody)
            {
                row.Draw();
            }
            CreateFood();
        }

        /// <summary>
        /// Создание еды
        /// </summary>
        public static void CreateFood()
        {
            Random rnd = new Random();
            int xFood;
            int yFood;
            bool isFoodCreated = false;
            while (!isFoodCreated)
            {
                xFood = rnd.Next(2, 79);
                yFood = rnd.Next(2, 29);
                Console.SetCursorPosition(xFood, yFood);
                //if () проверка на координаты змеи
                //{
                //    isFoodCreated = true;
                //    Point food = (xFood, yFood, 'O');
                //    food.Draw();
                //}
            }
            
        }


    }
}
