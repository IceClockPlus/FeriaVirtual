﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaVirtual.Database.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name{ get; set; }
        public string ImageUrl { get; set; }
        public byte[] Timestamp { get; set; }

    }
}
