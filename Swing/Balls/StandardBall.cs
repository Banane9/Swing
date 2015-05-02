using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing.Balls
{
    /// <summary>
    /// Represents the standard <see cref="Ball"/> that is always available and used to make matches.
    /// </summary>
    public sealed class StandardBall : Ball
    {
        private const int minWeight = 1;
        private static readonly Random random = new Random();
        private static readonly List<Sprite> sprites = new List<Sprite>();
        private readonly uint weight;
        private Sprite sprite;

        public override bool AppearsInReservoir
        {
            get { return true; }
        }

        public override uint Cooldown
        {
            get { return 0; }
        }

        public override string Description
        {
            get { return "The standard Ball that is always available and used to make matches."; }
        }

        public override bool IsCompressable
        {
            get { return true; }
        }

        public override bool IsUnmodifiable
        {
            get { return false; }
        }

        public override uint Level
        {
            get { return 0; }
        }

        public override string Name
        {
            get { return "Standard Ball"; }
        }

        public override uint RequiredBallsForCompression
        {
            get { return 4; }
        }

        public override Sprite Sprite
        {
            get { return sprite; }
        }

        public override uint Weight
        {
            get { return weight; }
        }

        public StandardBall(Game game)
        {
            sprite = sprites[random.Next((int)Math.Min((int)Math.Max(game.Level, game.MinColorCount), sprites.Count))];
            weight = (uint)random.Next(minWeight, (int)Math.Max(game.Level, game.MinWeight));
        }

        public override Ball GetThrowResult(Game game)
        {
            // return new HeartBall(this);
            return base.GetThrowResult(game);
        }

        public override bool Matches(Ball other)
        {
            var asStandardBall = other as StandardBall;
            if (asStandardBall == null)
                return false;

            return asStandardBall.Sprite == Sprite;
        }
    }
}