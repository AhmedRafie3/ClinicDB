using System;
using System.Collections.Generic;

namespace Infrastructure.Models;

public partial class TbStaticDataType
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<TbStaticDatum> TbStaticData { get; set; } = new List<TbStaticDatum>();
}
