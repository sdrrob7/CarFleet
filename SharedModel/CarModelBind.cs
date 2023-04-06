using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class CarModelBind
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public int ModelId { get; set; }

        public int? ColorId { get; set; }

        public int? Year { get; set; }

        public string? Transmission { get; set; }
    }
}
