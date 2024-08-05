﻿using System;
using System.Collections.Generic;

namespace QuanLiKhoHang.Models;

public partial class InputInfo
{
    public string Id { get; set; } = null!;

    public string IdObject { get; set; } = null!;

    public string IdInput { get; set; } = null!;

    public int? Count { get; set; }

    public double? InputPrice { get; set; }

    public double? OutputPrice { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public virtual Input IdInputNavigation { get; set; } = null!;

    public virtual ObjectItem IdObjectNavigation { get; set; } = null!;

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();

    public virtual UserApp? User { get; set; }
}
