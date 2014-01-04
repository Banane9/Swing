using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Api
{
    /// <summary>
    /// Represents a Ball.
    /// </summary>
    public abstract class Ball
    {
        #region Properties

        /// <summary>
        /// Gets the weight of the Ball.
        /// </summary>
        public byte Weight { get; private set; }

        /// <summary>
        /// Gets the <see cref="Uri"/> of the Ball's sprite.
        /// </summary>
        public Uri SpriteUri { get; private set; }

        /// <summary>
        /// Gets whether the Ball can be played from the dropper.
        /// </summary>
        public bool IsPlayable { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Gets executed when the Ball collides with another Ball. Doesn't do anything.
        /// </summary>
        /// <param name="ball">The other Ball.</param>
        public virtual void OnCollision(Ball ball) { }

        #endregion
    }
}
