using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing
{
    /// <summary>
    /// Represents a Ball.
    /// </summary>
    public abstract class Ball
    {
        /// <summary>
        /// Gets whether the <see cref="Ball"/> will naturally appear in the reservoir.
        /// </summary>
        public abstract bool AppearsInReservoir { get; }

        /// <summary>
        /// Gets the number of <see cref="Ball"/>s that have to be dropped until this one will be available again.
        /// </summary>
        public abstract uint Cooldown { get; }

        /// <summary>
        /// Gets the description of the <see cref="Ball"/>.
        /// </summary>
        public abstract string Description { get; }

        /// <summary>
        /// Gets whether the <see cref="Ball"/> is compressable or not.
        /// </summary>
        public abstract bool IsCompressable { get; }

        /// <summary>
        /// Gets whether the <see cref="Ball"/> can be changed by effects or not.
        /// </summary>
        public abstract bool IsUnmodifiable { get; }

        /// <summary>
        /// Gets the level that is required for the <see cref="Ball"/> to appear.
        /// </summary>
        public abstract uint Level { get; }

        /// <summary>
        /// Gets the name of the <see cref="Ball"/>.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets the number of <see cref="Ball"/>s required for a stack of these <see cref="Ball"/>s to compress.
        /// </summary>
        public abstract uint RequiredBallsForCompression { get; }

        /// <summary>
        /// Gets the sprite of the <see cref="Ball"/>.
        /// </summary>
        public abstract Sprite Sprite { get; }

        /// <summary>
        /// Gets the weight of the Ball.
        /// </summary>
        public abstract uint Weight { get; }

        /// <summary>
        /// Gets executed when another <see cref="Ball"/> gets dropped on it.
        /// <para/>
        /// Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> that is dropped onto this <see cref="Ball"/>.</param>
        public virtual void DroppedOnBy(Ball ball)
        {
        }

        /// <summary>
        /// Gets executed when the <see cref="Ball"/> is dropped on another <see cref="Ball"/>.
        /// <para/>
        /// Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> this <see cref="Ball"/> is dropped onto.</param>
        public virtual void DropsOn(Ball ball)
        {
        }

        /// <summary>
        /// Creates the <see cref="Ball"/> that this one turns into when thrown off screen.
        /// <para/>
        /// Returns itself by default.
        /// </summary>
        /// <param name="game">The current game.</param>
        /// <returns>The <see cref="Ball"/> that this one turns into when thrown off screen.</returns>
        public virtual Ball GetThrowResult(Game game)
        {
            return this;
        }

        /// <summary>
        /// Checks whether this <see cref="Ball"/> would form a match with the other one.
        /// <para/>
        /// Returns <code>false</code> by default.
        /// </summary>
        /// <param name="other">The other <see cref="Ball"/>.</param>
        /// <returns>Whether this <see cref="Ball"/> would form a match with the other one.</returns>
        public virtual bool Matches(Ball other)
        {
            return false;
        }

        /// <summary>
        /// Provides a string representation of the Ball.
        /// </summary>
        /// <returns>The Name of the Ball.</returns>
        public override string ToString()
        {
            return Name + " (" + Weight + ")";
        }
    }
}