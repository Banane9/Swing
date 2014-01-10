using Swing.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Balls
{
    public class StandardBall : Ball
    {
        static StandardBall()
        {
            BallRegistry.AddStandardBall("StandardBall", typeof(StandardBall));
        }

        /// <summary>
        /// Provides a string representation of the Ball.
        /// </summary>
        /// <returns>The Name of the Ball.</returns>
        public new static string ToString()
        {
            return Information.Name;
        }

        /// <summary>
        /// Represents the Information about a Ball.
        /// </summary>
        public new class Information : Ball.Information
        {
            /// <summary>
            /// Gets the Name of the Ball.
            /// </summary>
            public new static readonly string Name = "Standard Ball";

            /// <summary>
            /// Gets the Description of the Ball.
            /// </summary>
            public new static readonly string Description = "The common Ball that does nothing special.";
        }
    }
}