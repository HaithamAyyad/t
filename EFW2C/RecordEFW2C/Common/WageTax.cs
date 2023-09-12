using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.RecordEFW2C.Common
{
    public class WageTaxMembers
    {
        public double EmployerAndEmployeeTaxRate { get; set; }
        public double MaxTaxedEarnings { get; set; }
        public double EmployeeMaxAnnualTax { get; set; }
        public double HouseHoldMinCoveredWages { get; set; }
    }

    public class  WageTax
    {
        public WageTaxMembers SocialSecurity { get; set; }
        public WageTaxMembers MediCare { get; set; }
    }
}
