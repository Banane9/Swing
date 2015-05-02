using Swing.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing.Balls
{
    public class StandardBall : Ball
    {
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
            get { return null; }
        }

        public override Type ThrowResult
        {
            get { return null; } // typeof(BrickBall);
        }

        public override uint Weight { get; private set; }
    }
}