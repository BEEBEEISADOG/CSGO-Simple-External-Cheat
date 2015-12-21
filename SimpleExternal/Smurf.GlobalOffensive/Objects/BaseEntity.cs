﻿using System;
using System.Numerics;
using Smurf.GlobalOffensive.Patchables;

namespace Smurf.GlobalOffensive.Objects
{
	/// <summary>
	///     Base type for all entities in the game.
	/// </summary>
	public class BaseEntity : NativeObject
	{
		/// <summary>
		///     Initializes a new instance of the <see cref="BaseEntity" /> class.
		/// </summary>
		/// <param name="baseAddress">The base address.</param>
		internal BaseEntity(IntPtr baseAddress) : base(baseAddress)
		{
		}

		/// <summary>
		///     Gets the identifier.
		/// </summary>
		/// <value>
		///     The identifier.
		/// </value>
		public int Id => ReadField<int>(StaticOffsets.Index);

		/// <summary>
		///     Gets this entity's position.
		/// </summary>
		/// <value>
		///     The position.
		/// </value>
		public Vector3 Position => ReadField<Vector3>(StaticOffsets.Position);

		/// <summary>
		///     Gets this entity's health.
		/// </summary>
		/// <value>
		///     The health.
		/// </value>
		public int Health => ReadField<int>(StaticOffsets.Health);

		/// <summary>
		///     Gets this entity's armor.
		/// </summary>
		/// <value>
		///     The armor.
		/// </value>
		public int Armor => ReadField<int>(StaticOffsets.Armor);

		/// <summary>
		///     Gets the entity's flags.
		/// </summary>
		/// <value>
		///     The flags.
		/// </value>
		public int Flags => ReadField<int>(StaticOffsets.Flags);

		/// <summary>
		///     Gets a value indicating whether this entity is dormant.
		/// </summary>
		/// <value>
		///     <c>true</c> if this instance is dormant; otherwise, <c>false</c>.
		/// </value>
		public bool IsDormant => ReadField<int>(StaticOffsets.Dormant) == 1;

		/// <summary>
		///     Gets a value indicating whether this entity is alive.
		/// </summary>
		/// <value>
		///     <c>true</c> if this instance is alive; otherwise, <c>false</c>.
		/// </value>
		public bool IsAlive => ReadField<byte>(StaticOffsets.LifeState) == 0;

		/// <summary>
		///     Gets a value indicating whether this instance is friendly.
		/// </summary>
		/// <value>
		///     <c>true</c> if this instance is friendly; otherwise, <c>false</c>.
		/// </value>
		public bool IsFriendly => Team == Smurf.Me.Team;

		/// <summary>
		///     Gets the team this entity is on.
		/// </summary>
		/// <value>
		///     The team.
		/// </value>
		public PlayerTeam Team => (PlayerTeam) ReadField<int>(StaticOffsets.Team);

		/// <summary>
		///     Gets the squared distance to this entity, relative to the local player.
		/// </summary>
		/// <value>
		///     The distance squared.
		/// </value>
		public float DistanceSqr => Vector3.DistanceSquared(Smurf.Me.Position, Position);

		/// <summary>
		///     Gets the distance to this entity, relative to the local player.
		/// </summary>
		/// <value>
		///     The distance.
		/// </value>
		public float Distance => Vector3.Distance(Smurf.Me.Position, Position);
	}
}