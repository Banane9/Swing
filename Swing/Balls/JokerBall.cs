using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing.Balls
{
    public sealed class JokerBall : Ball
    {
        public override bool AppearsInReservoir
        {
            get { return true; }
        }

        public override uint Cooldown
        {
            get { return 40; }
        }

        public override string Description
        {
            get { return "Matches with any Standard Ball."; }
        }

        public override bool IsCompressable
        {
            get { return false; }
        }

        public override bool IsUnmodifiable
        {
            get { return true; }
        }

        public override uint Level
        {
            get { return 4; }
        }

        public override string Name
        {
            get { return "Joker Ball"; }
        }

        public override uint RequiredBallsForCompression
        {
            get { return uint.MaxValue; }
        }

        public override Sprite Sprite
        {
            get { return null; }
        }

        public override uint Weight
        {
            get { return 1; }
        }

        public override bool Matches(Ball other)
        {
            return other is StandardBall || other is JokerBall;
        }
    }
}