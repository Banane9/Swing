using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Api
{
    public abstract partial class Ball
    {
        #region Dropping

        #region Drops On

        /// <summary>
        /// Gets executed when the <see cref="Ball"/> is dropped another <see cref="Ball"/>. Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> this <see cref="Ball"/> is dropped onto.</param>
        public virtual void DropsOn(Ball ball) { }

        #endregion Drops On

        #region Dropped On By

        /// <summary>
        /// Gets executed when another <see cref="Ball"/> gets dropped on it. Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> that is dropped onto this <see cref="Ball"/>.</param>
        public virtual void DroppedOnBy(Ball ball) { }

        #endregion Dropped On By

        #endregion Dropping

        #region ToString

        /// <summary>
        /// Provides a string representation of the Ball.
        /// </summary>
        /// <returns>The Name of the Ball.</returns>
        public override string ToString()
        {
            return GetBallName(this.GetType(), System.Globalization.CultureInfo.CurrentUICulture.TwoLetterISOLanguageName) + " (" + Weight + ")";
        }

        #endregion ToString
    }
}
