using Swing.Api;
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
        private readonly Dictionary<BallColor, Sprite> sprites = new Dictionary<BallColor, Sprite>();

        public override bool AppearsInReservoir
        {
            get { return true; }
        }

        /// <summary>
        /// Gets or sets this <see cref="StandardBall"/>'s color.
        /// </summary>
        public BallColor Color { get; set; }

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
            get { return sprites[Color]; }
        }

        public override uint Weight { get; private set; }

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

            return asStandardBall.Color == Color;
        }

        public enum BallColor
        {
            LightBlue,
            DarkBlue,
            Turqoise,
            LightGreen,
            DarkGreen,
            Pink,
            Red,
            Purple,
            Orange,
            Yellow,
        }
    }
}