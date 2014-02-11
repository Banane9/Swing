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
    public abstract class Ball
    {
        #region Properties

        /// <summary>
        /// Gets the weight of the Ball.
        /// </summary>
        public byte Weight { get; private set; }

        #endregion Properties

        #region Methods

        #region Dropping

        /// <summary>
        /// Gets executed when the <see cref="Ball"/> is dropped another <see cref="Ball"/>. Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> this <see cref="Ball"/> is dropped onto.</param>
        public virtual void DropsOn(Ball ball)
        {
        }

        /// <summary>
        /// Gets executed when another <see cref="Ball"/> gets dropped on it. Doesn't do anything by default.
        /// </summary>
        /// <param name="ball">The <see cref="Ball"/> that is dropped onto this <see cref="Ball"/>.</param>
        public virtual void DroppedOnBy(Ball ball)
        {
        }

        #endregion Dropping

        #region ToString Override

        /// <summary>
        /// Provides a string representation of the Ball.
        /// </summary>
        /// <returns>The Name of the Ball.</returns>
        public override string ToString()
        {
            return GetBallName(this.GetType(), CultureInfo.CurrentUICulture.TwoLetterISOLanguageName) + " (" + Weight + ")";
        }

        #endregion ToString Override

        #region Getting the Values of the Attributes

        #region Type Check Helper

        /// <summary>
        /// Throws an Exception if the passed Type is not a Subclass of <see cref="Ball"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check.</param>
        /// <param name="senderFunction">Name of the sender function, for the Exception message.</param>
        /// <exception cref="System.ArgumentException"/>
        private static void throwIfNotBall(Type type, string senderFunction)
        {
            if (!type.IsSubclassOf(typeof(Ball))) throw new ArgumentException(senderFunction + " can only be with on Subclasses of the Ball Class.", "ballType");
        }

        #endregion Type Check Helper

        #region Name

        /// <summary>
        /// Returns the Name of the <see cref="Ball"/> in the specified language. Defaults to English if there's none with the specified language code. If there's no english one it uses the first.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> that the Description is wanted for.</param>
        /// <param name="language">The two letter language code.</param>
        /// <returns>The Name of the <see cref="Ball"/>.</returns>
        /// <exception cref="System.ArgumentExeption"/>
        public static string GetBallName(Type ballType, string language = "en")
        {
            if (language.Length != 2) throw new ArgumentException("Language needs to be a two letter code.", "language");

            throwIfNotBall(ballType, "GetBallName");

            NameAttribute[] nameAttributes = ((NameAttribute[])ballType.GetCustomAttributes(typeof(NameAttribute), false));

            if (nameAttributes.Length == 0) return "No Name";

            if (nameAttributes.Any(attribute => attribute.Language == language))
            {
                return nameAttributes.First(attribute => attribute.Language == attribute.Language).Name;
            }

            if (nameAttributes.Any(attribute => attribute.Language == "en"))
            {
                return nameAttributes.First(attribute => attribute.Language == "en").Name;
            }

            return nameAttributes.First().Name;
        }

        #endregion Name

        #region Description

        /// <summary>
        /// Returns the Description of the <see cref="Ball"/> in the specified language. Defaults to English if there's none with the specified language code. If there's no english one it uses the first.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> that the Description is wanted for.</param>
        /// <param name="language">The two letter language code.</param>
        /// <returns>The Description of the <see cref="Ball"/>.</returns>
        /// <exception cref="System.ArgumentException"/>
        public static string GetBallDescription(Type ballType, string language = "en")
        {
            if (language.Length != 2) throw new ArgumentException("Language needs to be a two letter code.", "language");

            throwIfNotBall(ballType, "GetBallDescription");

            DescriptionAttribute[] descriptionAttributes = ((DescriptionAttribute[])ballType.GetCustomAttributes(typeof(DescriptionAttribute), false));

            if (descriptionAttributes.Length == 0) return "No Description";

            if (descriptionAttributes.Any(attribute => attribute.Language == language))
            {
                return descriptionAttributes.First(attribute => attribute.Language == language).Description;
            }

            if (descriptionAttributes.Any(attribute => attribute.Language == "en"))
            {
                return descriptionAttributes.First(attribute => attribute.Language == "en").Description;
            }

            return descriptionAttributes.First().Description;
        }

        #endregion Description

        #region Sprite

        /// <summary>
        /// Returns the Path to the Sprite of the <see cref="Ball"/>.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> the Path is wanted for.</param>
        /// <returns>The Path to the Sprite or "No Sprite".</returns>
        public static string GetBallSpritePath(Type ballType)
        {
            throwIfNotBall(ballType, "GetBallSpritePath");

            SpriteAttribute[] spriteAttributes = (SpriteAttribute[])ballType.GetCustomAttributes(typeof(SpriteAttribute), false);

            return spriteAttributes.Length > 0 ? spriteAttributes.First().Path : "No Sprite";
        }

        #endregion

        #region PlayerLevel

        /// <summary>
        /// Returns the level that the Player must have for the <see cref="Ball"/> to appear.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> the level is wanted for.</param>
        /// <returns>The level at which the <see cref="Ball"/> starts to appear.</returns>
        /// <exception cref="System.ArgumentException"/>
        public static uint GetBallPlayerLevel(Type ballType)
        {
            throwIfNotBall(ballType, "GetBallAppearsInReservoirLevel");

            LevelAttribute[] appearsInReservoirAttributes = (LevelAttribute[])ballType.GetCustomAttributes(typeof(LevelAttribute), false);

            return appearsInReservoirAttributes.Length > 0 ? appearsInReservoirAttributes.First().PlayerLevel : 0;
        }

        #endregion PlayerLevel

        #region AppearsInReservoir

        /// <summary>
        /// Returns whether the <see cref="Ball"/> can appear in the Reservoir.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> that the check is wanted for.</param>
        /// <returns>Whether the <see cref="Ball"/> can appear in the Reservoir.</returns>
        /// <exception cref="System.ArgumentException"/>
        public static bool GetBallAppearsInReservoir(Type ballType)
        {
            throwIfNotBall(ballType, "GetBallAppearsInReservoir");

            return ballType.GetCustomAttributes(typeof(AppearsInReservoirAttribute), false).Count() > 0;
        }

        #endregion AppearsInReservoir

        #region IsSpecial

        /// <summary>
        /// Returns whether the <see cref="Ball"/> is special.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> that the check is wanted for.</param>
        /// <returns>Whether the <see cref="Ball"/> is special.</returns>
        /// <exception cref="System.ArgumentException"/>
        public static bool GetBallIsSpecial(Type ballType)
        {
            throwIfNotBall(ballType, "GetBallIsSpecial");

            return ballType.GetCustomAttributes(typeof(SpecialAttribute), false).Count() > 0;
        }

        #endregion IsSpecial

        #region SpecialDroppedBalls

        /// <summary>
        /// Returns the number of <see cref="Ball"/>s that have to be dropped between appearances of the special <see cref="Ball"/>.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> that the number of <see cref="Ball"/>s that have to be dropped is wanted for. Use GetBallIsSpecial(ballType) to check whether it's a special <see cref="Ball"/>.</param>
        /// <returns>The number of <see cref="Ball"/>s that have to be dropped between appearances.</returns>
        /// <exception cref="System.ArgumentException"/>
        public static uint GetBallSpecialDroppedBalls(Type ballType)
        {
            throwIfNotBall(ballType, "GetBallSpecialDroppedBalls");

            SpecialAttribute[] specialAttributes = (SpecialAttribute[])ballType.GetCustomAttributes(typeof(SpecialAttribute), false);

            if (specialAttributes.Length == 0) throw new ArgumentException("Ball needs to have the Special Attribute for this. Use GetBallIsSpecial(ballType) to check.", "ballType");

            return specialAttributes.First().DroppedBalls;
        }

        #endregion SpecialDroppedBalls

        #region HasThrowResult

        /// <summary>
        /// Returns whether the <see cref="Ball"/> has a Throw Result.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> that the check is wanted for.</param>
        /// <returns>Whether the <see cref="Ball"/> has a Throw Result.</returns>
        /// <exception cref="System.ArgumentException"/>
        public static bool GetBallHasThrowResult(Type ballType)
        {
            throwIfNotBall(ballType, "GetBallHasThrowResult");

            return ballType.GetCustomAttributes(typeof(ThrowResultsInAttribute), false).Count() > 0;
        }

        #endregion HasThrowResult

        #region ThrowResultsIn

        /// <summary>
        /// Returns the Type of the <see cref="Ball"/> that results in this <see cref="Ball"/> being thrown.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> that the resulting <see cref="Ball"/>'s <see cref="Type"/> is wanted for. Use GetBallHasThrowResult(ballType) to check whether it has a Throw Result.</param>
        /// <returns>The <see cref="Type"/> of the resulting <see cref="Ball"/>.</returns>
        /// <exception cref="System.ArgumentException"/>
        public static Type GetBallThrowResultsInType(Type ballType)
        {
            throwIfNotBall(ballType, "GetBallThrowResultsInType");

            ThrowResultsInAttribute[] throwResultsInAttributes = (ThrowResultsInAttribute[])ballType.GetCustomAttributes(typeof(ThrowResultsInAttribute), false);

            if (throwResultsInAttributes.Count() == 0) throw new ArgumentException("Ball needs to have ThrowResultsIn Attribute for this. Use GetBallHasThrowResult(ballType) to check.", "ballType");

            return throwResultsInAttributes.First().BallType;
        }

        #endregion

        #endregion Getting the Values of the Attributes

        #endregion Methods

        #region Attributes

        #region Name

        /// <summary>
        /// Represents the Name of the <see cref="Ball"/> it is used on and the language the Name is for. Can only be used on Classes derived from <see cref="Ball"/>. Can (and should) be used more than once.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        protected sealed class NameAttribute : Attribute
        {
            /// <summary>
            /// Gets the two letter code for the language this Name is for.
            /// </summary>
            public readonly string Language;

            /// <summary>
            /// Gets the Name for the <see cref="Ball"/> it was used on.
            /// </summary>
            public readonly string Name;

            /// <summary>
            /// Initializes a <see cref="NameAttribute"/> for the <see cref="Ball"/>.
            /// </summary>
            /// <param name="language">Two letter code for the language the Name is for.</param>
            /// <param name="name">Name of the Ball.</param>
            /// <exception cref="System.ArgumentException"/>
            public NameAttribute(string language, string name)
            {
                if (language.Length != 2) throw new ArgumentException("Language needs to be a two letter code.", "language");

                Language = language.ToLower();
                Name = name;
            }
        }

        #endregion Name

        #region Description

        /// <summary>
        /// Represents the Description of the <see cref="Ball"/> it is used on and the language the Description is for. Can only be used on Classes derived from <see cref="Ball"/>. Can (and should) be used more than once.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        protected sealed class DescriptionAttribute : Attribute
        {
            /// <summary>
            /// Gets the two letter code for the language this Dscription is for.
            /// </summary>
            public readonly string Language;

            /// <summary>
            /// Gets the Description for the <see cref="Ball"/> it was used on.
            /// </summary>
            public readonly string Description;

            /// <summary>
            /// Initialized a <see cref="DescriptionAttribute"/> for the <see cref="Ball"/>.
            /// </summary>
            /// <param name="language">Two letter code for the language the Description is for.</param>
            /// <param name="description">Description of the Ball.</param>
            /// <exception cref="System.ArgumentException"/>
            public DescriptionAttribute(string language, string description)
            {
                if (language.Length != 2) throw new ArgumentException("Language needs to be a two letter code.", "language");

                language = Language;
                Description = description;
            }
        }

        #endregion Description

        #region Sprite

        /// <summary>
        /// Represents the Information about the Sprite of the <see cref="Ball"/> it is used on.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class SpriteAttribute : Attribute
        {
            /// <summary>
            /// Gets the Path of the Sprite.
            /// </summary>
            public readonly string Path;

            /// <summary>
            /// Initializes a <see cref="SpriteAttribute"/> for the <see cref="Ball"/>.
            /// </summary>
            /// <param name="path">Path of the Sprite.</param>
            public SpriteAttribute(string path)
            {
                Path = path;
            }
        }

        #endregion Sprite

        #region Level

        /// <summary>
        /// Represents the level that the Player must have before the <see cref="Ball"/> it is used on starts to appear.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class LevelAttribute : Attribute
        {
            /// <summary>
            /// Gets the level that the Player must have before this <see cref="Ball"/> appears.
            /// </summary>
            public readonly uint PlayerLevel;

            /// <summary>
            /// Initializes a <see cref="LevelAttribute"/> for the <see cref="Ball"/>.
            /// </summary>
            /// <param name="playerLevel">Level the Player must have before this <see cref="Ball"/> appears.</param>
            public LevelAttribute(uint playerLevel)
            {
                PlayerLevel = playerLevel;
            }
        }

        #endregion Level

        #region AppearsInReservoir

        /// <summary>
        /// Marks the <see cref="Ball"/> it is used on as being able to appear in the Ball Reservoir.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class AppearsInReservoirAttribute : Attribute { }

        #endregion AppearsInReservoir

        #region Special

        /// <summary>
        /// Marks the <see cref="Ball"/> it is used on as Special and stores how many <see cref="Ball"/>s have to be dropped between appearances of it.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class SpecialAttribute : Attribute
        {
            /// <summary>
            /// Gets the number of <see cref="Ball"/>s that have to be dropped.
            /// </summary>
            public readonly uint DroppedBalls;

            /// <summary>
            /// Initializes a <see cref="SpecialAttribute"/> for the <see cref="Ball"/>.
            /// </summary>
            /// <param name="droppedBalls">Number of <see cref="Ball"/>s that have to be dropped.</param>
            public SpecialAttribute(uint droppedBalls)
            {
                DroppedBalls = droppedBalls;
            }
        }

        #endregion Special

        #region ThrowResultsIn

        /// <summary>
        /// Marks the <see cref="Ball"/> it is used on as having a different result when thrown around and stores the <see cref="Type"/> of the resulting <see cref="Ball"/>.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class ThrowResultsInAttribute : Attribute
        {
            /// <summary>
            /// Gets the <see cref="Type"/> of the resulting <see cref="Ball"/>.
            /// </summary>
            public readonly Type BallType;
 
            /// <summary>
            /// Initializes a <see cref="ThrowResultsInAttribute"/> for the <see cref="Ball"/>.
            /// </summary>
            /// <param name="ballType"><see cref="Type"/> of the resulting <see cref="Ball"/>.</param>
            /// <exception cref="System.ArgumentException"/>
            public ThrowResultsInAttribute(Type ballType)
            {
                if (!ballType.IsSubclassOf(typeof(Ball))) throw new ArgumentException("Ball Type has to be a Type inheriting from the Ball Class", "ballType");

                BallType = ballType;
            }
        }

        #endregion ThrowResultsIn

        #endregion Attributes
    }
}