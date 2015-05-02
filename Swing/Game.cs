using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing
{
    /// <summary>
    /// Contains information about a game.
    /// </summary>
    public class Game
    {
        /// <summary>
        /// Gets or sets the current level of the game.
        /// </summary>
        public uint Level { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of colors for the <see cref="StandardBall"/>s of the game.
        /// </summary>
        public uint MinColorCount { get; set; }

        /// <summary>
        /// Gets or sets the minimum weight for the <see cref="StandardBall"/>s of the game.
        /// </summary>
        public uint MinWeight { get; set; }
    }
}