﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.filters
{
    public class UserFilter
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? RoleName { get; set; }
    }
}
