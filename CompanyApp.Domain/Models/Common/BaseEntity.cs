﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyApp.Domain.Models.Common
{

    public abstract class BaseEntity
    {
      
        public int Id { get; set; }
        public DateTime CreatedTime { get; set; }
    }

}
