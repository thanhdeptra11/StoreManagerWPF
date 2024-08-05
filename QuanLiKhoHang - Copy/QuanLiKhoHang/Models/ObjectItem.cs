using System;
using System.Collections.Generic;

namespace QuanLiKhoHang.Models;

public partial class ObjectItem
{
    public string Id { get; set; } = null!;

    public string? DisplayName { get; set; }

    public int IdUnit { get; set; }

    public int IdSupplier { get; set; }

    public virtual Supplier IdSupplierNavigation { get; set; } = null!;

    public virtual Unit IdUnitNavigation { get; set; } = null!;

    public virtual ICollection<InputInfo> InputInfos { get; set; } = new List<InputInfo>();

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
