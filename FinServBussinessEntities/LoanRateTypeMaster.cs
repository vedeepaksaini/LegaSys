﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinServBussinessEntities
{
    public class LoanRateTypeMaster
    {
        public int ID { get; set; }
        public string LoanRateType { get; set; }
        public bool IsActive { get; set; }
    }
}