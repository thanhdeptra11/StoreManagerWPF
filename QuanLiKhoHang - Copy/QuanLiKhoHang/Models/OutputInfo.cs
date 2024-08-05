using System;
using System.Collections.Generic;

namespace QuanLiKhoHang.Models;

public partial class OutputInfo
{
    public string Id { get; set; } = null!;

    public string IdObject { get; set; } = null!;

    public string IdOutput { get; set; } = null!;

    public string IdInputInfo { get; set; } = null!;

    public int IdCustomer { get; set; }

    public int? Count { get; set; }

    public string? Status { get; set; }

    public int? UserId { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual InputInfo IdInputInfoNavigation { get; set; } = null!;

    public virtual ObjectItem IdObjectNavigation { get; set; } = null!;

    public virtual Output IdOutputNavigation { get; set; } = null!;

    public virtual UserApp? User { get; set; }
}
