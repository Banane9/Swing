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

        #endregion Properties

        #region Methods

        /// <summary>
        /// Gets executed when the <see cref="Ball"/> is dropped another <see cref="Ball"/>. Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> this <see cref="Ball"/> is dropped onto.</param>
        public virtual void DropsOn(Ball ball)
        {
        }

        /// <summary>
        /// Gets executed when another <see cref="Ball"/> gets dropped on it. Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> that is dropped onto this <see cref="Ball"/>.</param>
        public virtual void DroppedOnBy(Ball ball)
        {
        }

        /// <summary>
        /// Provides a string representation of the Ball.
        /// </summary>
        /// <returns>The Name of the Ball.</returns>
        public static string ToString()
        {
            return Information.Name;
        }

        #endregion Methods

        #region Information

        /// <summary>
        /// Represents the Information about a Ball.
        /// </summary>
        public abstract class Information
        {
            /// <summary>
            /// Gets the Name of the Ball.
            /// </summary>
            public static readonly string Name = "Abstract Ball";

            /// <summary>
            /// Gets the Description of the Ball.
            /// </summary>
            public static readonly string Description = "The Base of every Ball.";
        }

        #endregion Information
    }
}