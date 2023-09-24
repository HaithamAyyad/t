﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.RecordEFW2C.Common
{
    internal class WageTaxData
    {
        public double TaxRate { get; set; }
        public double MaxTaxedEarnings { get; set; }
        public double EmployeeMaxAnnualTax { get; set; }
        public double MinHouseHoldCoveredWages { get; set; }
    }

    internal class  WageTax
    {
        public WageTaxData SocialSecurity { get; set; }
        public WageTaxData MediCare { get; set; }
    }
}
