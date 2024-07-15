using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace EldenRingBuildBackend.Models;

public partial class Build
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public string? BuildName { get; set; }

    public string? Weapon1 { get; set; }

    public string? Weapon2 { get; set; }

    public string? ArmorHead { get; set; }

    public string? ArmorBody { get; set; }

    public string? ArmorHands { get; set; }

    public string? ArmorLegs { get; set; }

    public string? AshOfWar { get; set; }
    public string? Talisman1 { get; set; }

    public string? Talisman2 { get; set; }

    public string? Talisman3 { get; set; }

    public string? Talisman4 { get; set; }

    public string? Spell1 { get; set; }

    public string? Spell2 { get; set; }

    public string? Spell3 { get; set; }

    public string? Spell4 { get; set; }

    public string? Spell5 { get; set; }

    public string? Spell6 { get; set; }

    public string? Spell7 { get; set; }

    public string? Spell8 { get; set; }

    public string? Spell9 { get; set; }

    public string? Spell10 { get; set; }

    public string? Spell11 { get; set; }

    public string? Spell12 { get; set; }

    public string? Classes { get; set; }

    public string? BuildCreator { get; set; }

    [JsonIgnore]
    public virtual ICollection<Created> Createds { get; set; } = new List<Created>();
    [JsonIgnore]
    public virtual ICollection<Favorite> Favorites { get; set; } = new List<Favorite>();
}
