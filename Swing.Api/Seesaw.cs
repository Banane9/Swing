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
        /// To what side the Seesaw is tilted.
        /// </summary>
        private TiltTypes tiltType;

        #endregion

        #region Properties

        public List<Ball> LeftBallStack { get; private set; }

        public List<Ball> RightBallStack { get; private set; }

        #endregion

        #region Constructor

        public Seesaw(TiltTypes tiltType, byte maximumExtension)
        {
            this.tiltType = tiltType;
            this.maximumExtension = maximumExtension;
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
    } 
}
