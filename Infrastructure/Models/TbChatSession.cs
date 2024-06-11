using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbChatSession
{
    public int Id { get; set; }

    public string? Topic { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual ICollection<TbChatMessage> TbChatMessages { get; set; } = new List<TbChatMessage>();

    public virtual ICollection<TbChatSessionUser> TbChatSessionUsers { get; set; } = new List<TbChatSessionUser>();
}
