using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Api
{
    /// <summary>
    /// Makes a method available that is used for <see cref="Ball"/>s that need to do stuff (special ones).
    /// </summary>
    public interface ITicking
    {
        /// <summary>
        /// Method that gets called for the Tick event.
        /// </summary>
        /// <param name="seesaws"><see cref="List"/> of <see cref="Seesaw"/>s that make up the play grid this is called from. Starts on the left.</param>
        void OnTick(List<Seesaw> seesaws);
    }
}
