using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Swing.Api
{
    public abstract partial class Ball
    {
        #region Name

        /// <summary>
        /// Represents the Name of the <see cref="Swing.Api.Ball"/> it is used on and the language the Name is for. Can only be used on Classes derived from <see cref="Swing.Api.Ball"/>. Can (and should) be used more than once.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        protected sealed class NameAttribute : Attribute
        {
            /// <summary>
            /// Gets the two letter code for the language this Name is for.
            /// </summary>
            public readonly string Language;

            /// <summary>
            /// Gets the Name for the <see cref="Swing.Api.Ball"/> it was used on.
            /// </summary>
            public readonly string Name;

            /// <summary>
            /// Initializes a <see cref="Swing.Api.Ball.NameAttribute"/> for the <see cref="Swing.Api.Ball"/>.
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
        /// Represents the Description of the <see cref="Swing.Api.Ball"/> it is used on and the language the Description is for. Can only be used on Classes derived from <see cref="Swing.Api.Ball"/>. Can (and should) be used more than once.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
        protected sealed class DescriptionAttribute : Attribute
        {
            /// <summary>
            /// Gets the two letter code for the language this Dscription is for.
            /// </summary>
            public readonly string Language;

            /// <summary>
            /// Gets the Description for the <see cref="Swing.Api.Ball"/> it was used on.
            /// </summary>
            public readonly string Description;

            /// <summary>
            /// Initialized a <see cref="Swing.Api.Ball.DescriptionAttribute"/> for the <see cref="Swing.Api.Ball"/>.
            /// </summary>
            /// <param name="language">Two letter code for the language the Description is for.</param>
            /// <param name="description">Description of the <see cref="Swing.Api.Ball"/>.</param>
            /// <exception cref="ArgumentException"/>
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
        /// Represents the Information about the Sprite of the <see cref="Swing.Api.Ball"/> it is used on.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class SpriteAttribute : Attribute
        {
            /// <summary>
            /// Gets the Path of the Sprite.
            /// </summary>
            public readonly string Path;

            /// <summary>
            /// Initializes a <see cref="Swing.Api.Ball.SpriteAttribute"/> for the <see cref="Swing.Api.Ball"/>.
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
        /// Represents the level that the Player must have before the <see cref="Swing.Api.Ball"/> it is used on starts to appear.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class LevelAttribute : Attribute
        {
            /// <summary>
            /// Gets the level that the Player must have before this <see cref="Swing.Api.Ball"/> appears.
            /// </summary>
            public readonly uint PlayerLevel;

            /// <summary>
            /// Initializes a <see cref="Swing.Api.Ball.LevelAttribute"/> for the <see cref="Swing.Api.Ball"/>.
            /// </summary>
            /// <param name="playerLevel">Level the Player must have before this <see cref="Swing.Api.Ball"/> appears.</param>
            public LevelAttribute(uint playerLevel)
            {
                PlayerLevel = playerLevel;
            }
        }

        #endregion Level

        #region AppearsInReservoir

        /// <summary>
        /// Marks the <see cref="Swing.Api.Ball"/> it is used on as being able to appear in the Ball Reservoir.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class AppearsInReservoirAttribute : Attribute
        {
			/// <summary>
            /// Initializes a <see cref="Swing.Api.Ball.AppearsInReservoirAttribute"/> for the <see cref="Swing.Api.Ball"/>.
			/// </summary>
            public AppearsInReservoirAttribute() { }
        }

        #endregion AppearsInReservoir

        #region Special

        /// <summary>
        /// Marks the <see cref="Swing.Api.Ball"/> it is used on as Special and stores how many <see cref="Swing.Api.Ball"/>s have to be dropped between appearances of it.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class SpecialAttribute : Attribute
        {
            /// <summary>
            /// Gets the number of <see cref="Swing.Api.Ball"/>s that have to be dropped.
            /// </summary>
            public readonly uint DroppedBalls;

            /// <summary>
            /// Initializes a <see cref="Swing.Api.Ball.SpecialAttribute"/> for the <see cref="Swing.Api.Ball"/>.
            /// </summary>
            /// <param name="droppedBalls">Number of <see cref="Swing.Api.Ball"/>s that have to be dropped.</param>
            public SpecialAttribute(uint droppedBalls)
            {
                DroppedBalls = droppedBalls;
            }
        }

        #endregion Special

        #region Unmodifiable

		/// <summary>
        /// Marks the <see cref="Swing.Api.Ball"/> it is used on as being unaffected by special <see cref="Swing.Api.Ball"/>s that modify other <see cref="Swing.Api.Ball"/>s.
		/// </summary>
		[AttributeUsage(AttributeTargets.Class)]
		protected sealed class UnmodifiableAttribute : Attribute
        {
			/// <summary>
            /// Initializes a <see cref="Swing.Api.Ball.UnmodifableAttribute"/> for the <see cref="Swing.Api.Ball"/>.
			/// </summary>
            public UnmodifiableAttribute() { }
        }

        #endregion Modifiable

        #region ThrowResultsIn

        /// <summary>
        /// Marks the <see cref="Swing.Api.Ball"/> it is used on as having a different result when thrown around and stores the <see cref="Type"/> of the resulting <see cref="Swing.Api.Ball"/>.
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        protected sealed class ThrowResultsInAttribute : Attribute
        {
            /// <summary>
            /// Gets the <see cref="System.Type"/> of the resulting <see cref="Swing.Api.Ball"/>.
            /// </summary>
            public readonly Type BallType;

            /// <summary>
            /// Initializes a <see cref="Swing.Api.Ball.ThrowResultsInAttribute"/> for the <see cref="Swing.Api.Ball"/>.
            /// </summary>
            /// <param name="ballType"><see cref="System.Type"/> of the resulting <see cref="Swing.Api.Ball"/>.</param>
            /// <exception cref="System.ArgumentException"/>
            public ThrowResultsInAttribute(Type ballType)
            {
                if (!ballType.IsSubclassOf(typeof(Ball))) throw new ArgumentException("Ball Type has to be a Type inheriting from the Ball Class", "ballType");

                BallType = ballType;
            }
        }

        #endregion ThrowResultsIn

        #region Compressable

		/// <summary>
        /// Marks the <see cref="Swing.Api.Ball"/> it is used on as being compressable and stores at which number of stacked <see cref="Swing.Api.Ball"/>s the compression occurs.
		/// </summary>
        [AttributeUsage(AttributeTargets.Class)]
		protected sealed class CompressableAttribute : Attribute
        {
			/// <summary>
            /// The number of <see cref="Swing.Api.Ball"/>s that need to be stacked for them to compress down into one.
			/// </summary>
            public readonly byte RequiredBalls;

			/// <summary>
            /// Initializes a <see cref="Swing.Api.Ball.CompressableAttribute"/> for the <see cref="Swing.Api.Ball"/>.
			/// </summary>
            /// <param name="requiredBalls">Number of required <see cref="Swing.Api.Ball"/>s that need to be stacked for them to compress.</param>
            /// <exception cref="System.ArgumentException"/>
			public CompressableAttribute(byte requiredBalls)
            {
                if (requiredBalls < 2) throw new ArgumentException("More than two Balls need to be required.", "requiredBalls");

                RequiredBalls = requiredBalls;
            }
        }

        #endregion Compressable
    }
}
