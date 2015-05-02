using System;
using System.Collections.Generic;
using System.Linq;

namespace Swing
{
    /// <summary>
    /// Represents the reservoir for <see cref="Ball"/>s that the <see cref="Crane"/> takes <see cref="Ball"/>s from.
    /// </summary>
    public sealed class BallReservoir
    {
        private readonly Game game;

        /// <summary>
        /// Gets the stored <see cref="Ball"/>s.
        /// </summary>
        // TODO: Add Custom Queue that keeps the Balls stocked automatically?
        public Queue<Ball>[] Balls { get; private set; }

        /// <summary>
        /// Creates a new instance of the <see cref="BallReservoir"/> class for the given <see cref="Game"/> with the given dimensions.
        /// </summary>
        /// <param name="game">The current game.</param>
        /// <param name="width">The width of the reservoir in Balls.</param>
        /// <param name="height">The height of the reservoir in Balls.</param>
        public BallReservoir(Game game, byte width, byte height)
        {
            if (width < 1)
                throw new ArgumentOutOfRangeException("width", "Width must be greater than 0");

            if (height < 1)
                throw new ArgumentOutOfRangeException("height", "Height must be greater than 0");

            this.game = game;
            Balls = generateReservoir(game, width, height).ToArray();
        }

        public Ball TakeBall(byte position)
        {
            Balls[position].Enqueue(getBall(game));

            return Balls[position].Dequeue();
        }

        private static IEnumerable<Queue<Ball>> generateReservoir(Game game, byte width, byte height)
        {
            for (var w = 0; w < width; ++w)
            {
                var queue = new Queue<Ball>(height);
                for (var h = 0; h < height; ++h)
                    queue.Enqueue(getBall(game));

                yield return queue;
            }
        }

        private static Ball getBall(Game game)
        {
            throw new NotImplementedException();
        }
    }
}