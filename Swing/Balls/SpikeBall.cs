using Swing.Api;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing.Balls
{
    /// <summary>
    /// Represents a spiked <see cref="Ball"/> that destroys other <see cref="Ball"/>s.
    /// </summary>
    public sealed class SpikeBall : Ball
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
            get { return "Spiked Ball, that will occasionally appear in the reservoir and destroy other Balls it's resting on or that are laying on top of it."; }
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
            get { return "Spike Ball"; }
        }

        public override uint RequiredBallsForCompression
        {
            get { return uint.MaxValue; }
        }

        public override Sprite Sprite
        {
            get { return null; }
        }

        public override Type ThrowResult
        {
            get { return null; }
        }

        public override uint Weight
        {
            get { return 1; }
        }
    }
}