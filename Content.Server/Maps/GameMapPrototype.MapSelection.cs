﻿namespace Content.Server.Maps;

public sealed partial class GameMapPrototype
{
    /// <summary>
    /// Controls if the map can be used as a fallback if no maps are eligible.
    /// </summary>
    [DataField("fallback")]
    public bool Fallback { get; }

    /// <summary>
    /// Controls if the map can be voted for.
    /// </summary>
    [DataField("votable")]
    public bool Votable { get; } = true;

    /// <summary>
    /// Minimum players for the given map.
    /// </summary>
    [DataField("minPlayers", required: true)]
    public uint MinPlayers { get; }

    /// <summary>
    /// Maximum players for the given map.
    /// </summary>
    [DataField("maxPlayers")]
    public uint MaxPlayers { get; } = uint.MaxValue;

    [DataField("conditions")] private readonly List<GameMapCondition> _conditions = new();

    /// <summary>
    /// The game map conditions that must be fulfilled for this map to be selectable.
    /// </summary>
    public IReadOnlyList<GameMapCondition> Conditions => _conditions;
}
