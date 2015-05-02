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
        public static Dictionary<string, Type> StandardBalls { get; private set; }

        /// <summary>
        /// Gets a <see cref="Dictionary"/> with the <see cref="Type"/>s of the registered <see cref="Ball"/>s that implement <see cref="ITHrowResult"/>.
        /// </summary>
        public static Dictionary<string, Type> ThrowResultBalls { get; private set; }

        #endregion Properties

        #region Constructor

        /// <summary>
        /// Initializes the <see cref="Dictionaries"/> for the <see cref="Ball"/> <see cref="Type"/>s.
        /// </summary>
        static BallRegistry()
        {
            StandardBalls = new Dictionary<string, Type>();
            ThrowResultBalls = new Dictionary<string, Type>();
        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Adds a <see cref="Ball"/> <see cref="Type"/> to the Registry.
        /// </summary>
        /// <param name="ballName">The name of the <see cref="Ball"/>.</param>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/>.</param>
        /// <returns>Whether the <see cref="Ball"/> <see cref="Type"/> was added or not.</returns>
        public static bool AddStandardBall(string ballName, Type ballType)
        {
            if (StandardBalls.ContainsKey(ballName) || StandardBalls.ContainsValue(ballType) || !ballType.IsSubclassOf(typeof(Ball))) return false;

            StandardBalls.Add(ballName, ballType);

            return true;
        }

        //Use different methods to add the different Balls (normal, throwresult, ...)

        #endregion Methods

        #region Ball Dictionary

        //private class BallDictionary : IDictionary<string, Type>, IEnumerable<KeyValuePair<string, Type>>
        //{
        //    /// <summary>
        //    /// <see cref="Dictionary"/> of the <see cref="Ball"/> <see cref="Type"/>s in this <see cref="BallDictionary"/>.
        //    /// </summary>
        //    private Dictionary<BallInformation, Type> ballDictionary = new Dictionary<BallInformation, Type>();

        //    public Type this[BallInformation index]
        //    {
        //        get { return ballDictionary[index]; }
        //    }

        //    #region Interface Implementation

        //    public void Add(BallInformation key, Type value)
        //    {
        //        ballDictionary.Add(key, value);
        //    }

        //    public bool ContainsKey(BallInformation key)
        //    {
        //        return ballDictionary.ContainsKey(key);
        //    }

        //    public ICollection<BallInformation> Keys
        //    {
        //        get { return ballDictionary.Keys; }
        //    }

        //    public bool Remove(BallInformation key)
        //    {
        //        return ballDictionary.Remove(key);
        //    }

        //    public bool TryGetValue(BallInformation key, out Type value)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    public ICollection<Type> Values
        //    {
        //        get { return ballDictionary.Values; }
        //    }

        //    public Type this[BallInformation key]
        //    {
        //        get
        //        {
        //            return ballDictionary[key];
        //        }
        //        set
        //        {
        //            ballDictionary[key] = value;
        //        }
        //    }

        //    public void Add(KeyValuePair<BallInformation, Type> item)
        //    {
        //        ballDictionary.Add(item.Key, item.Value);
        //    }

        //    public void Clear()
        //    {
        //        ballDictionary.Clear();
        //    }

        //    public bool Contains(KeyValuePair<BallInformation, Type> item)
        //    {
        //        return ballDictionary.Contains(item);
        //    }

        //    public int Count
        //    {
        //        get { return ballDictionary.Count; }
        //    }

        //    public bool Remove(KeyValuePair<BallInformation, Type> item)
        //    {
        //        return ballDictionary.Remove(item.Key);
        //    }

        //    public IEnumerator<KeyValuePair<BallInformation, Type>> GetEnumerator()
        //    {
        //        return ballDictionary.GetEnumerator();
        //    }

        //    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        //    {
        //        return GetEnumerator();
        //    }

        //    #endregion
        //}

        #endregion Ball Dictionary
    }
}