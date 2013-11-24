﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sfx.Security
{
    public abstract class Principal
    {
        public string Id { get; protected set; }
        public string Name { get; set; }
        public string Token { get; set; }
    }
}
