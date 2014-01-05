using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Api
{
    /// <summary>
    /// Represents a static registry for the available Balltypes.
    /// </summary>
    public static class BallRegistry
    {
        #region Properties

        /// <summary>
        /// Gets a <see cref="Dictionary"/> with the <see cref="Type"/>s of the registered <see cref="Ball"/>s matched to their name.
        /// </summary>
        public static Dictionary<string, Type> Balls { get; private set; }

        /// <summary>
        /// Gets a <see cref="Dictionary"/> with the <see cref="Type"/>s of the registered <see cref="Ball"/>s that implement <see cref="ITHrowResult"/>.
        /// </summary>
        public static Dictionary<string, Type> ThrowResultBalls { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Adds a <see cref="Ball"/> <see cref="Type"/> to the Registry.
        /// </summary>
        /// <param name="ballName">The name of the <see cref="Ball"/>.</param>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/>.</param>
        /// <returns>Whether the <see cref="Ball"/> <see cref="Type"/> was added or not.</returns>
        public static bool AddBall(string ballName, Type ballType)
        {
            if (Balls.ContainsKey(ballName) || Balls.ContainsValue(ballType) || !ballType.IsSubclassOf(typeof(Ball))) return false;

            Balls.Add(ballName, ballType);

            if (typeof(IThrowResult).IsAssignableFrom(ballType)) ThrowResultBalls.Add(ballName, ballType);

            return true;

            //Just testing something...
            //Seesaw s = new Seesaw(Seesaw.TiltTypes.Balanced, 3);
            //uint w = s.RightBallStack.Weight;
        }

        #endregion
    }
}
