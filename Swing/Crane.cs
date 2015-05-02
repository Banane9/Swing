using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing
{
    /// <summary>
    /// Represents the crane that picks <see cref="Ball"/>s from the <see cref="BallReservoir"/> and drops them onto the Seesaws.
    /// </summary>
    public sealed class Crane
    {
        public Ball CurrentBall { get; private set; }
    }
}