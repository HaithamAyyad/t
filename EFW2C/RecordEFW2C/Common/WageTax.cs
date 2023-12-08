using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.RecordEFW2C.Common
{
    internal class WageTaxData
    {
        public decimal TaxRate { get; set; }
        public decimal MaxTaxedEarnings { get; set; }
        public decimal EmployeeMaxAnnualTax { get; set; }
        public decimal MinHouseHoldCoveredWages { get; set; }
    }

    internal class  WageTax
    {
        public WageTaxData SocialSecurity { get; set; }
        public WageTaxData MediCare { get; set; }
    }
}
