using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class ColorTbl
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<CarTbl> CarTbls { get; } = new List<CarTbl>();
}
