using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbChatMessage
{
    public int Id { get; set; }

    public int SessionId { get; set; }

    public int UserId { get; set; }

    public string MessageText { get; set; } = null!;

    public int DocumentId { get; set; }

    public byte[] DateCreated { get; set; } = null!;

    public virtual TbDocument Document { get; set; } = null!;

    public virtual TbChatSession Session { get; set; } = null!;

    public virtual TbChatSessionUser User { get; set; } = null!;
}
