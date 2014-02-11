using Swing.Api;
using Swing.Balls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Swing.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Standard Ball Name: " + Ball.GetBallName(typeof(StandardBall)));
            Console.WriteLine("Standard Ball Description: " + Ball.GetBallDescription(typeof(StandardBall)));
            Console.WriteLine("Standard Ball IsSpecial: " + Ball.GetBallIsSpecial(typeof(StandardBall)));
            //Console.WriteLine("Standard Ball Special DroppedBalls: " + Ball.GetBallSpecialDroppedBalls(typeof(StandardBall)));
            Console.WriteLine("Spiked Ball ToString: " + new SpikeBall().ToString());
            Console.WriteLine("Spiked Ball Description: " + Ball.GetBallDescription(typeof(SpikeBall)));

            //Apparently the static constructor only gets called once a static direct member of the class is called

            //foreach (KeyValuePair<string, CultureInfo> culture in new Dictionary<string, CultureInfo> { { "Current Culture", CultureInfo.CurrentCulture }, { "Current UI Culture", CultureInfo.CurrentUICulture }, { "Installed UI Culture", CultureInfo.InstalledUICulture }, { "Invariant Culture", CultureInfo.InvariantCulture } })
            //{
            //    Console.WriteLine(culture.Key + ":");

            //    foreach (PropertyInfo propertyInfo in typeof(CultureInfo).GetProperties())
            //    {
            //        Console.WriteLine("    " + propertyInfo.Name + ": " + propertyInfo.GetValue(culture.Value, null));
            //    }
            //    Console.WriteLine();
            //}
            Console.ReadLine();
        }
    }
}