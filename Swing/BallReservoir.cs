using Swing.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing
{
    public sealed class BallReservoir
    {
        public Ball[,] Balls { get; private set; }

        public BallReservoir(byte width, byte height)
        {
            if (width < 1) throw new ArgumentOutOfRangeException("width", "Value must be greater than 0");
            if (height < 1) throw new ArgumentOutOfRangeException("height", "Value must be greater than 0");

            Balls = new Ball[width * 2, height];
        }

        public Ball TakeBall(byte position)
        {
            Ball toReturn = Balls[position, 0];

            return toReturn;
        }
    }
}