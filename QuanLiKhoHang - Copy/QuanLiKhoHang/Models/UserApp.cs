using System;
using System.Collections.Generic;

namespace QuanLiKhoHang.Models;

public partial class UserApp
{
    public int Id { get; set; }

    public string? DisplayName { get; set; }

    public string? UserName { get; set; }

    public string? Password { get; set; }

    public int IdRole { get; set; }

    public string? Request { get; set; }
    
    public string? Email {  get; set; }

    public virtual UserRole IdRoleNavigation { get; set; } = null!;

    public virtual ICollection<InputInfo> InputInfos { get; set; } = new List<InputInfo>();

    public virtual ICollection<OutputInfo> OutputInfos { get; set; } = new List<OutputInfo>();
}
