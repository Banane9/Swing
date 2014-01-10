using Swing.Api;
using Swing.Balls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Standard Ball Name: " + StandardBall.ToString());
            Console.WriteLine("Spiked Ball Name: " + SpikeBall.ToString());
            Console.WriteLine("Ball Name: " + Ball.Information.Name);
            //MakeList<Ball>(new StandardBall(), new SpikeBall()).ForEach(Console.WriteLine);

            //Apparently the static constructor only gets called once a static direct member of the class is called
            foreach (KeyValuePair<string, Type> ball in BallRegistry.StandardBalls)
            {
                Console.WriteLine(ball.Key + ": " + ball.Value.InvokeMember("ToString", System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.InvokeMethod, null, null, null));
            }
            Console.ReadLine();
        }

        //Derping in IRC :D
        //public static List<T> MakeList<T>(params T[] items)
        //{
        //    List<T> list = new List<T>();
        //    foreach (T item in items)
        //    { list.Add(item); }

        //    return list;
        //}
    }
}