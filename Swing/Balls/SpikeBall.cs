using Swing.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Balls
{
    [Name("en", "Spike Ball")]
    [Description("en", "Destroys Balls over and under it on contact.")]
    public class SpikeBall : Ball
    {
        static SpikeBall()
        {
            BallRegistry.AddStandardBall("SpikeBall", typeof(SpikeBall));
        }
    }
}