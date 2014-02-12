using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Globalization;

namespace Swing.Api
{
    /// <summary>
    /// Represents a Ball.
    /// </summary>
    [Name("en", "Abstract Ball")]
    [Description("en", "The Base of every Ball.")]
    public abstract partial class Ball
    {
        #region Weight

        /// <summary>
        /// Gets the weight of the Ball.
        /// </summary>
        public uint Weight { get; private set; }

        #endregion Weight
    }
}