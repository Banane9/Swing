using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing.Api
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
        /// Gets the <see cref="Type"/> of <see cref="Ball"/> that this one turns into when thrown off screen.
        /// </summary>
        public abstract Type ThrowResult { get; }

        /// <summary>
        /// Gets the weight of the Ball.
        /// </summary>
        public abstract uint Weight { get; }

        /// <summary>
        /// Gets executed when another <see cref="Ball"/> gets dropped on it. Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> that is dropped onto this <see cref="Ball"/>.</param>
        public virtual void DroppedOnBy(Ball ball)
        {
        }

        /// <summary>
        /// Gets executed when the <see cref="Ball"/> is dropped another <see cref="Ball"/>. Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> this <see cref="Ball"/> is dropped onto.</param>
        public virtual void DropsOn(Ball ball)
        {
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