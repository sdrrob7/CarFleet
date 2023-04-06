﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class CarViewModel
    {
        public int Id { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public string? Transmission { get; set; }
        public string? Color { get; set; }
        public int? Year { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
