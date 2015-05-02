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
        private static readonly List<Sprite> sprites = new List<Sprite>();
        private Sprite sprite;
        private uint weight;

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

        public override Ball GetThrowResult()
        {
            // return new BrickBall(this);
            return base.GetThrowResult();
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