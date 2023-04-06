﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedModel
{
    public class UserModelBind
    {
        //public Guid Id { get; set; }
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string UserName { get; set; } = null!;

        public string Password { get; set; } = null!;
    }
}
