using System.Collections.Generic;
using System.Linq;

namespace Swing
{
    /// <summary>
    /// Represents a Seesaw for <see cref="Ball"/>s.
    /// </summary>
    public class Seesaw
    {
        #region Members & Properties

        /// <summary>
        /// How many balls to throw up if the tilt changes significantly enough.
        /// </summary>
        private byte maximumBallsToThrowUp;

        /// <summary>
        /// Maximum extension of a Seesaw arm.
        /// </summary>
        private byte maximumExtension;

        #region Tilt Type

        /// <summary>
        /// To what side the Seesaw is tilted.
        /// </summary>
        private TiltTypes tiltType;

        /// <summary>
        /// Gets the Tilt Type of the <see cref="Seesaw"/>.
        /// </summary>
        public TiltTypes TiltType
        {
            get { return tiltType; }
            private set
            {
                if (value != tiltType)
                {
                    tiltType = value;

                    if (TiltChanged != null) TiltChanged();
                }
            }
        }

        #endregion Tilt Type

        #region BallStacks

        #region Left BallStack

        /// <summary>
        /// The <see cref="BallStack"/> on the left side of the <see cref="Seesaw"/>.
        /// </summary>
        private BallStack leftBallStack;

        /// <summary>
        /// The <see cref="BallStack"/> on the left side of the <see cref="Seesaw"/> as <see cref="IEnumerable"/>.
        /// </summary>
        public IEnumerable<Ball> LeftBallStack
        {
            get { return (IEnumerable<Ball>)leftBallStack; }
        }

        #endregion Left BallStack

        #region Right BallStack

        /// <summary>
        /// The <see cref="BallStack"/> on the right side of the <see cref="Seesaw"/>.
        /// </summary>
        private BallStack rightBallStack;

        /// <summary>
        /// The <see cref="BallStack"/> on the right side of the <see cref="Seesaw"/> as <see cref="IEnumerable"/>.
        /// </summary>
        public IEnumerable<Ball> RightBallStack
        {
            get { return (IEnumerable<Ball>)rightBallStack; }
        }

        #endregion Right BallStack

        #endregion BallStacks

        #endregion Members & Properties

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

            leftBallStack = new BallStack();
            leftBallStack.WeightChanged += weightingChanged;

            rightBallStack = new BallStack();
            rightBallStack.WeightChanged += weightingChanged;
        }

        #endregion Constructor

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
                    leftBallStack.AddBallOnTop(ball);
                    break;

                case Sides.Right:
                    rightBallStack.AddBallOnTop(ball);
                    break;
            }
        }

        /// <summary>
        /// Handler method for the WeightingChanged event of the <see cref="BallStack"/>.
        /// </summary>
        private void weightingChanged()
        {
            TiltTypes newTilt = TiltTypes.Balanced;

            if (leftBallStack.Weight > rightBallStack.Weight)
            {
                newTilt = TiltTypes.Left;

                if (tiltType != TiltTypes.Balanced)
                {
                    uint weightAdded = leftBallStack.Weight - rightBallStack.Weight;

                    byte ballsThrownUp = 0;
                    uint weightThrownUp = 0;

                    while (weightThrownUp <= weightAdded && rightBallStack.Count > 0 && ballsThrownUp < maximumBallsToThrowUp)
                    {
                        ballsThrownUp++;

                        Ball ballThrownUp = rightBallStack.TakeTopBall();
                        weightThrownUp += ballThrownUp.Weight;

                        if (BallThrownUp != null) BallThrownUp(ballThrownUp);
                    }
                }
            }
            else if (rightBallStack.Weight > leftBallStack.Weight)
            {
                newTilt = TiltTypes.Right;

                if (tiltType != TiltTypes.Balanced)
                {
                    uint weightAdded = rightBallStack.Weight - leftBallStack.Weight;

                    byte ballsThrownUp = 0;
                    uint weightThrownUp = 0;

                    while (weightThrownUp <= weightAdded && leftBallStack.Count > 0 && ballsThrownUp < maximumBallsToThrowUp)
                    {
                        ballsThrownUp++;

                        Ball ballThrownUp = leftBallStack.TakeTopBall();
                        weightThrownUp += ballThrownUp.Weight;

                        if (BallThrownUp != null) BallThrownUp(ballThrownUp);
                    }
                }
            }

            TiltType = newTilt;
        }

        #endregion Methods

        #region Internal Types

        #region BallStack

        /// <summary>
        /// Represents a stack of <see cref="Balls"/> on one side of the <see cref="Seesaw"/>
        /// </summary>
        private class BallStack : IEnumerable<Ball>
        {
            #region Members & Properties

            /// <summary>
            /// <see cref="List"/> of <see cref="Ball"/>s in this <see cref="BallStack"/>.
            /// </summary>
            private List<Ball> stack = new List<Ball>();

            #region Weight

            /// <summary>
            /// Backing variable for the Weight property.
            /// </summary>
            private uint weight = 0;

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

            #endregion Weight

            #region Count

            /// <summary>
            /// Returns the number of <see cref="Ball"/>s in the <see cref="BallStack"/>.
            /// </summary>
            public int Count
            {
                get { return stack.Count; }
            }

            #endregion Count

            #endregion Members & Properties

            #region Weight Changed Event

            /// <summary>
            /// Delegate for the WeightChanged Event.
            /// </summary>
            public delegate void WeightChangedHandler();

            /// <summary>
            /// Fires when the Weight of the <see cref="BallStack"/> changed.
            /// </summary>
            public event WeightChangedHandler WeightChanged;

            #endregion Weight Changed Event

            #region IEnumerable Implementation

            /// <summary>
            /// Returns a <see cref="IEnumerator"/> that goes through the <see cref="BallStack"/> from bottom to top.
            /// </summary>
            /// <returns>The <see cref="IEnumerator"/> for the <see cref="BallStack"/>.</returns>
            public IEnumerator<Ball> GetEnumerator()
            {
                return stack.GetEnumerator();
            }

            /// <summary>
            /// Returns a <see cref="IEnumerator"/> that goes through the <see cref="BallStack"/> from bottom to top.
            /// </summary>
            /// <returns>The <see cref="IEnumerator"/> for the <see cref="BallStack"/>.</returns>
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            #endregion IEnumerable Implementation

            #region Indexer

            /// <summary>
            /// Indexes the <see cref="BallStack"/>. Starts at the bottom.
            /// </summary>
            /// <param name="index">The index of the <see cref="Ball"/>.</param>
            /// <returns>The <see cref="Ball"/> at the specified index.</returns>
            public Ball this[int index]
            {
                get
                {
                    return stack[index];
                }
                private set
                {
                    stack[index] = value;

                    Weight = (uint)stack.Sum(stackBall => stackBall.Weight);
                }
            }

            #endregion Indexer

            #region Stack Modification

            /// <summary>
            /// Drops a <see cref="Ball"/> onto the <see cref="BallStack"/>.
            /// </summary>
            /// <param name="ball">The <see cref="Ball"/> that will be added to the <see cref="BallStack"/>.</param>
            public void AddBallOnTop(Ball ball)
            {
                Ball topBall = stack.LastOrDefault();

                topBall.DroppedOnBy(ball);
                ball.DropsOn(topBall);

                stack.Add(ball);
            }

            /// <summary>
            /// Takes the top <see cref="Ball"/> from the <see cref="BallStack"/> and returns it.
            /// </summary>
            /// <returns>The top <see cref="Ball"/>.</returns>
            public Ball TakeTopBall()
            {
                Ball ball = stack.LastOrDefault();

                stack.RemoveAt(stack.Count - 1);

                return ball;
            }

            #endregion Stack Modification
        }

        #endregion BallStack

        #region TiltTypes

        /// <summary>
        /// Represents the possible ways a <see cref="Seesaw"/> can be tilted.
        /// </summary>
        public enum TiltTypes
        {
            Balanced,
            Left,
            Right
        }

        #endregion TiltTypes

        #region Sides

        /// <summary>
        /// Represents the possible sides of a <see cref="Seesaw"/>.
        /// </summary>
        public enum Sides
        {
            Left,
            Right
        }

        #endregion Sides

        #endregion Internal Types

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

        #endregion Balance Changed

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

        #endregion Ball Thrown Up

        #endregion Events
    }
}