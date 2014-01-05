using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Api
{
    /// <summary>
    /// Represents a Seesaw for <see cref="Ball"/>s.
    /// </summary>
    public class Seesaw
    {
        #region Members

        /// <summary>
        /// Maximum extension of a Seesaw arm.
        /// </summary>
        private byte maximumExtension;

        /// <summary>
        /// How many balls to throw up if the tilt changes significantly enough.
        /// </summary>
        private byte maximumBallsToThrowUp;

        /// <summary>
        /// To what side the Seesaw is tilted.
        /// </summary>
        private TiltTypes tiltType;

        #endregion

        #region BallStacks

        /// <summary>
        /// The <see cref="BallStack"/> on the left side of the <see cref="Seesaw"/>.
        /// </summary>
        public BallStack LeftBallStack { get; private set; }

        /// <summary>
        /// The <see cref="BallStack"/> on the right side of the <see cref="Seesaw"/>.
        /// </summary>
        public BallStack RightBallStack { get; private set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new Instance of the <see cref="Seesaw"/> Class.
        /// </summary>
        /// <param name="maximumExtension">The maximum Extension of the Seesaw (on one side).</param>
        /// <param name="maximumBallsToThrowUp">The number of balls to throw up if the tilt changes significantly enough.</param>
        public Seesaw(byte maximumExtension, byte maximumBallsToThrowUp)
        {
            this.maximumExtension = maximumExtension;
            this.maximumBallsToThrowUp = maximumBallsToThrowUp;

            LeftBallStack = new BallStack();
            LeftBallStack.WeightChanged += weightingChanged;

            RightBallStack = new BallStack();
            RightBallStack.WeightChanged += weightingChanged;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Drops a <see cref="Ball"/> on one of the <see cref="Sides"/> of the <see cref="Seesaw"/>.
        /// </summary>
        /// <param name="side">The side to drop the <see cref="Ball"/> on.</param>
        /// <param name="ball">The <see cref="Ball"/> being dropped.</param>
        public void DropBall(Sides side, Ball ball)
        {
            switch (side)
            {
                case Sides.Left:
                    LeftBallStack.AddBallOnTop(ball);
                    break;

                case Sides.Right:
                    RightBallStack.AddBallOnTop(ball);
                    break;
            }
        }

        /// <summary>
        /// Handler method for the WeightingChanged event of the <see cref="BallStack"/>.
        /// </summary>
        private void weightingChanged()
        {
            TiltTypes newTilt = TiltTypes.Balanced;

            if (LeftBallStack.Weight > RightBallStack.Weight)
            {
                newTilt = TiltTypes.Left;

                if (tiltType != TiltTypes.Balanced)
                {
                    uint weightAdded = LeftBallStack.Weight - RightBallStack.Weight;

                    byte ballsThrownUp = 0;
                    uint weightThrownUp = 0;

                    while (weightThrownUp <= weightAdded && RightBallStack.Count() > 0 && ballsThrownUp < maximumBallsToThrowUp)
                    {
                        ballsThrownUp++;

                        Ball ballThrownUp = RightBallStack.TakeTopBall();
                        weightThrownUp += ballThrownUp.Weight;

                        if (BallThrownUp != null) BallThrownUp(ballThrownUp);
                    }
                }
            }
            else if (RightBallStack.Weight > LeftBallStack.Weight)
            {
                newTilt = TiltTypes.Right;

                if (tiltType != TiltTypes.Balanced)
                {
                    uint weightAdded = RightBallStack.Weight - LeftBallStack.Weight;

                    byte ballsThrownUp = 0;
                    uint weightThrownUp = 0;

                    while (weightThrownUp <= weightAdded && LeftBallStack.Count() > 0 && ballsThrownUp < maximumBallsToThrowUp)
                    {
                        ballsThrownUp++;

                        Ball ballThrownUp = LeftBallStack.TakeTopBall();
                        weightThrownUp += ballThrownUp.Weight;

                        if (BallThrownUp != null) BallThrownUp(ballThrownUp);
                    }
                }
            }

            if (newTilt != tiltType)
            {
                if (TiltChanged != null) TiltChanged();
            }
        }

        #endregion

        #region Internal Types

        #region BallStack

        /// <summary>
        /// Represents a stack of <see cref="Balls"/> on one side of the <see cref="Seesaw"/>
        /// </summary>
        private class BallStack : IEnumerable<Ball>
        {
            #region Members
            
            /// <summary>
            /// <see cref="List"/> of <see cref="Ball"/>s in this <see cref="BallStack"/>.
            /// </summary>
            private List<Ball> stack = new List<Ball>();

            /// <summary>
            /// Backing variable for the Weight property.
            /// </summary>
            private uint weight = 0;

            #endregion

            #region Weight Property

            /// <summary>
            /// Gets the sum of the weights of all the <see cref="Ball"/>s in the <see cref="BallStack"/>.
            /// </summary>
            public uint Weight
            {
                get { return weight; }
                private set
                {
                    if (weight != value)
                    {
                        weight = value;

                        if (WeightChanged != null) WeightChanged();
                    }
                }
            }

            #endregion

            #region Stack Modification

            /// <summary>
            /// Drops a <see cref="Ball"/> onto the <see cref="BallStack"/>.
            /// </summary>
            /// <param name="ball">The <see cref="Ball"/> that will be added to the <see cref="BallStack"/>.</param>
            public void AddBallOnTop(Ball ball)
            {
                stack.LastOrDefault().DroppedOnBy(ball);
                ball.DropsOn(stack.LastOrDefault());

                stack.Add(ball);

                Weight = (uint)stack.Sum(stackBall => stackBall.Weight);
            }

            /// <summary>
            /// Takes the top <see cref="Ball"/> from the <see cref="BallStack"/> and returns it.
            /// </summary>
            /// <returns>The top <see cref="Ball"/>.</returns>
            public Ball TakeTopBall()
            {
                Ball ball = stack.LastOrDefault();

                stack.RemoveAt(stack.Count - 1);

                Weight = (uint)stack.Sum(stackBall => stackBall.Weight);

                return ball;
            }

            #endregion

            #region IEnumerable Implementation

            /// <summary>
            /// Returns a <see cref="IEnumerator"/> that goes through the <see cref="BallStack"/> from bottom to top.
            /// </summary>
            /// <returns></returns>
            public IEnumerator<Ball> GetEnumerator()
            {
                return stack.GetEnumerator();
            }

            #endregion

            #region Indexing

            /// <summary>
            /// Indexes the <see cref="BallStack"/>. Starts at the bottom.
            /// </summary>
            /// <param name="index">The index of the <see cref="Ball"/>.</param>
            /// <returns>The <see cref="Ball"/> at the specified index.</returns>
            public Ball this[int index]
	        {
                get { return stack[index]; }
	        }

            #endregion

            #region Weight Changed Event

            public delegate void WeightChangedHandler();
            public event WeightChangedHandler WeightChanged;

            #endregion
        }

        #endregion

        #region TiltTypes

        /// <summary>
        /// Represents the possible directions a <see cref="Seesaw"/> can be tilted to.
        /// </summary>
        public static enum TiltTypes
        {
            Balanced,
            Left,
            Right
        }

        #endregion

        #region Sides

        /// <summary>
        /// Represents the possible sides of a <see cref="Seesaw"/>.
        /// </summary>
        public static enum Sides
        {
            Left,
            Right
        }

        #endregion

        #endregion

        #region Events

        #region Balance Changed

        /// <summary>
        /// Handler Delegate for the TiltChanged Event.
        /// </summary>
        public delegate void TiltChangedHandler();

        /// <summary>
        /// Fires when the Tilt of the <see cref="Seesaw"/> changes.
        /// </summary>
        public event TiltChangedHandler TiltChanged;

        #endregion

        #region Ball Thrown Up

        /// <summary>
        /// Handler Delegate for the BallThrownUp Event.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> that was thrown up.</param>
        public delegate void BallThrownUpHandler(Ball ball);

        /// <summary>
        /// Fires when a <see cref="Ball"/> is thrown up from the <see cref="Seesaw"/>.
        /// </summary>
        public event BallThrownUpHandler BallThrownUp;

        #endregion

        #endregion
    } 
}
