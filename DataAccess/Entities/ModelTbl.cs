using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class ModelTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int MakeId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public virtual ICollection<CarTbl> CarTbls { get; } = new List<CarTbl>();

    public virtual MakeTbl Make { get; set; } = null!;
}
