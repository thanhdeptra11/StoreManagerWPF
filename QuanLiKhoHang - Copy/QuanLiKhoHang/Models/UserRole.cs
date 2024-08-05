using System;
using System.Collections.Generic;

namespace QuanLiKhoHang.Models;

public partial class UserRole
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public virtual ICollection<UserApp> UserApps { get; set; } = new List<UserApp>();
}
