using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing
{
    /// <summary>
    /// Represents a static registry for the available Balltypes.
    /// </summary>
    public static class BallRegistry
    {
        /// <summary>
        /// Gets all available <see cref="Ball"/>s.
        /// </summary>
        public static Dictionary<Type, Func<Game, Ball>> Balls { get; private set; }

        /// <summary>
        /// Gets all <see cref="Ball"/>s that can spawn in the <see cref="BallReservoir"/>.
        /// </summary>
        public static Dictionary<Type, Func<Game, Ball>> ReservoirBalls { get; private set; }

        /// <summary>
        /// Initializes the <see cref="Dictionaries"/> for the <see cref="Ball"/> <see cref="Type"/>s.
        /// </summary>
        static BallRegistry()
        {
            Balls = new Dictionary<Type, Func<Game, Ball>>();
            ReservoirBalls = new Dictionary<Type, Func<Game, Ball>>();
        }

        /// <summary>
        /// Adds a <see cref="Ball"/> to the Registry.
        /// </summary>
        /// <typeparam name="TBall">The type of the <see cref="Ball"/> to be added.</typeparam>
        /// <param name="create">A function that takes the current <see cref="Game"/> information and constructs a new instance of TBall.</param>
        public static void AddBall<TBall>(Func<Game, TBall> create) where TBall : Ball, new()
        {
            var ballType = typeof(TBall);

            if (Balls.ContainsKey(ballType))
                throw new ArgumentException("Ball already registered!", "TBall");

            Balls.Add(ballType, create);

            if (new TBall().AppearsInReservoir)
                ReservoirBalls.Add(ballType, create);
        }
    }
}