using System.Collections.ObjectModel;

namespace Swing.Api
{
    /// <summary>
    /// Makes a constructor available that takes a <see cref="Ball"/>. Means a derivative of the <see cref="Ball"/> Class implementing this can be the result of a <see cref="Ball"/> being thrown.
    /// </summary>
    public interface IThrowResult
    {
        /// <summary>
        /// Creates a new instance from the <see cref="Ball"/> that was thrown up.  this 
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> that was thrown up. Will be one of the <see cref="Ball"/>s that are accepted by this <see cref="IThrowResult"/>.</param>
        Ball CreateFromBall(Ball ball);

        /// <summary>
        /// <see cref="Collection"/> of <see cref="Ball"/> names this <see cref="IThrowResult"/> can be achieved from.
        /// </summary>
        Collection<string> AchievableFrom { get; }
    }
}
