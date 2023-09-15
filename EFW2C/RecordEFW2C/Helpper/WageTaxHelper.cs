using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using test.RecordEFW2C.Common;

namespace EFW2C.Common.Helper
{
    public class WageTaxHelper
    {
        public static Dictionary<int, WageTax> _wageTaxTable;
        
        //public static Dictionary<int, WageTax> WageTaxTable { get { return _wageTaxTable; } }

        public static void CreateWageTaxTable()
        {
            if (_wageTaxTable != null)
                return;

            var table = new Dictionary<int, WageTax>();

            var tableName = "MaximumWagesAndTaxTable.xml";

            try
            {
                var xDocument = XDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream($"EFW2C.Resources.{tableName}"));

                var tableElm = xDocument.Element("Table");
                var yearsElms = tableElm.Elements("Years");
                var yearElmList = yearsElms.Elements("Year") as IEnumerable<XElement>;

                foreach (var yearElm in yearElmList)
                {
                    var yearStr = yearElm.Attribute("value").Value;
                    var bothStr = yearElm.Attribute("both").Value;

                    var employee = null as WageTaxPerson;
                    var employer = null as WageTaxPerson;

                    if (bool.Parse(bothStr))
                    {
                        employee = employer = GetWageTaxPerson(yearElm);
                    }
                    else
                    {
                        var employerEml = yearElm.Element("Employer");
                        employer = GetWageTaxPerson(employerEml);
                        var employeeEml = yearElm.Element("Employee");
                        employee = GetWageTaxPerson(employeeEml);
                    }

                    var wageTax = new WageTax()
                    {
                        Employer = employer,
                        Employee = employee,
                    };

                    table.Add(int.Parse(yearStr), wageTax);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't open {tableName} {ex.Message}");
            }

            _wageTaxTable = table;
        }

        private static WageTaxPerson GetWageTaxPerson(XElement element)
        {
            var socialSecurityElm = element.Element("SocialSecurity");
            var taxRate = socialSecurityElm.Attribute("TaxRate").Value;
            var maxTaxedEarning = socialSecurityElm.Attribute("MaxTaxedEarning").Value;
            var employeeMaxAnnualTax = socialSecurityElm.Attribute("EmployeeMaxAnnualTax").Value;
            var minHouseHoldCoveredWages = socialSecurityElm.Attribute("MinHouseHoldCoveredWages").Value;

            var socialSecurityData = new WageTaxData()
            {
                TaxRate = double.Parse(taxRate),
                MaxTaxedEarnings = double.Parse(maxTaxedEarning),
                EmployeeMaxAnnualTax = double.Parse(employeeMaxAnnualTax),
                MinHouseHoldCoveredWages = double.Parse(minHouseHoldCoveredWages)
            };

            var medicareElm = element.Element("Medicare");
            taxRate = medicareElm.Attribute("TaxRate").Value;
            maxTaxedEarning = medicareElm.Attribute("MaxTaxedEarning").Value;
            employeeMaxAnnualTax = medicareElm.Attribute("EmployeeMaxAnnualTax").Value;

            var medicareData = new WageTaxData()
            {
                TaxRate = double.Parse(taxRate),
                MaxTaxedEarnings = double.Parse(maxTaxedEarning),
                EmployeeMaxAnnualTax = double.Parse(employeeMaxAnnualTax),
            };

            return new WageTaxPerson() { SocialSecurity = socialSecurityData, MediCare = medicareData };
        }

        public static WageTax GetWageTax(int year)
        {
            if (_wageTaxTable != null)
                if(_wageTaxTable.ContainsKey(year))
                    return _wageTaxTable[year];

            return null;
        }

    }
}
