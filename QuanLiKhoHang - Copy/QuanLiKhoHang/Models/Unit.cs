using System;
using System.Collections.Generic;

namespace QuanLiKhoHang.Models;

public partial class Unit
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public virtual ICollection<ObjectItem> ObjectItems { get; set; } = new List<ObjectItem>();
}
