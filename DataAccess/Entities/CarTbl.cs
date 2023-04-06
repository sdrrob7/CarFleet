using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public partial class CarTbl
{
    public int Id { get; set; }

    public int MakeId { get; set; }

    public int ModelId { get; set; }

    public int? ColorId { get; set; }

    public int? Year { get; set; }

    public DateTime CreatedDate { get; set; }

    public string? Transmission { get; set; }

    public virtual ColorTbl? Color { get; set; }

    public virtual MakeTbl Make { get; set; } = null!;

    public virtual ModelTbl Model { get; set; } = null!;
}
