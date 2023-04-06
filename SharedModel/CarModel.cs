using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class CarModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MakeId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
