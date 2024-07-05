﻿using System;
using System.Collections.Generic;

namespace EldenRingBuildBackend.Models;

public partial class Favorite
{
    public int Id { get; set; }

    public string? UserId { get; set; }

    public int? BuildId { get; set; }

    public virtual Build? Build { get; set; }
}
