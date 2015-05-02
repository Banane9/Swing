using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing
{
    /// <summary>
    /// Represents the parts of the playing field.
    /// </summary>
    public sealed class PlayingField
    {
        /// <summary>
        /// Gets the <see cref="BallReservoir"/> that the <see cref="Crane"/> takes the <see cref="Ball"/>s from.
        /// </summary>
        public BallReservoir BallReservoir { get; private set; }

        /// <summary>
        /// Gets the <see cref="Crane"/> that picks <see cref="Ball"/>s from the <see cref="BallReservoir"/> and drops them onto the Seesaws.
        /// </summary>
        public Crane Crane { get; private set; }

        /// <summary>
        /// Gets the <see cref="Ball"/>s on the Seesaws.
        /// </summary>
        public Ball[][] Seesaws { get; private set; }
    }
}