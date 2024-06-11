using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbChatSessionUser
{
    public int Id { get; set; }

    public int SessionId { get; set; }

    public int User1Id { get; set; }

    public int User2Id { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbChatSession Session { get; set; } = null!;

    public virtual ICollection<TbChatMessage> TbChatMessages { get; set; } = new List<TbChatMessage>();

    public virtual TbUser User1 { get; set; } = null!;

    public virtual TbUser User2 { get; set; } = null!;
}
