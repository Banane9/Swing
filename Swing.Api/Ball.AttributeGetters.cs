using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Api
{
    public abstract partial class Ball
    {
        #region Type Check Helper

        /// <summary>
        /// Throws an Exception if the passed Type is not a Subclass of <see cref="Ball"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to check.</param>
        /// <param name="senderFunction">Name of the sender function, for the Exception message.</param>
        /// <exception cref="System.ArgumentException"/>
        private static void throwIfNotBall(Type type, string senderFunction)
        {
            if (!type.IsSubclassOf(typeof(Ball))) throw new ArgumentException(senderFunction + " can only be on Subclasses of the Ball Class.", "ballType");
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

        #endregion Sprite

        #region PlayerLevel

        /// <summary>
        /// Returns the level that the Player must have for the <see cref="Ball"/> to appear. Degfaults to 0 if no attribute is present.
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

        #region ThrowResultsIn

        /// <summary>
        /// Returns the Type of the <see cref="Ball"/> that results in this <see cref="Ball"/> being thrown.
        /// </summary>
        /// <param name="ballType">The <see cref="Type"/> of the <see cref="Ball"/> that the resulting <see cref="Ball"/>'s <see cref="Type"/> is wanted for. Returns the passed in <see cref="Type"/> if it doesn't have the Attribute.</param>
        /// <returns>The <see cref="Type"/> of the resulting <see cref="Ball"/>.</returns>
        /// <exception cref="System.ArgumentException"/>
        public static Type GetBallThrowResultsInType(Type ballType)
        {
            throwIfNotBall(ballType, "GetBallThrowResultsInType");

            ThrowResultsInAttribute[] throwResultsInAttributes = (ThrowResultsInAttribute[])ballType.GetCustomAttributes(typeof(ThrowResultsInAttribute), false);

            return throwResultsInAttributes.Count() > 0 ? throwResultsInAttributes.First().BallType : ballType;
        }

        #endregion ThrowResultsIn
    }
}
