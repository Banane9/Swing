using Swing.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Balls
{
    [Name("en", "Standard Ball")]
    [Description("en", "The standard Ball that does nothing.")]
    public class StandardBall : Ball
    {
        static StandardBall()
        {
            BallRegistry.AddStandardBall("StandardBall", typeof(StandardBall));
        }
    }
}