﻿using EFW2C.Languages;
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
    internal class WageTaxHelper
    {
        public static Dictionary<int, WageTax> _wageTaxTabel;
        
        //public static Dictionary<int, WageTax> WageTaxTabel { get { return _wageTaxTabel; } }

        public static void CreateWageTaxTabel()
        {
            if (_wageTaxTabel != null)
                return;

            var tabel = new Dictionary<int, WageTax>();

            var tabelName = "MaximumWagesAndTaxTabel.xml";

            try
            {
                var xDocument = XDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream($"EFW2C.Resources.{tabelName}"));

                var tabelElm = xDocument.Element("Tabel");
                var yearsElms = tabelElm.Elements("Years");
                var yearElmList = yearsElms.Elements("Year") as IEnumerable<XElement>;

                foreach (var yearElm in yearElmList)
                {
                    var yearStr = yearElm.Attribute("value").Value;

                    tabel.Add(int.Parse(yearStr), GetWageTax(yearElm));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Can't open {tabelName} {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            _wageTaxTabel = tabel;
        }

        private static WageTax GetWageTax(XElement element)
        {
            var socialSecurityElm = element.Element("SocialSecurity");
            var taxRate = socialSecurityElm.Attribute("TaxRate").Value;
            var maxTaxedEarning = socialSecurityElm.Attribute("MaxTaxedEarning").Value;
            var employeeMaxAnnualTax = socialSecurityElm.Attribute("EmployeeMaxAnnualTax").Value;
            var minHouseHoldCoveredWages = socialSecurityElm.Attribute("MinHouseHoldCoveredWages").Value;

            var socialSecurityData = new WageTaxData()
            {
                TaxRate = decimal.Parse(taxRate),
                MaxTaxedEarnings = decimal.Parse(maxTaxedEarning),
                EmployeeMaxAnnualTax = decimal.Parse(employeeMaxAnnualTax),
                MinHouseHoldCoveredWages = decimal.Parse(minHouseHoldCoveredWages)
            };

            var medicareElm = element.Element("Medicare");
            taxRate = medicareElm.Attribute("TaxRate").Value;
            maxTaxedEarning = medicareElm.Attribute("MaxTaxedEarning").Value;
            employeeMaxAnnualTax = medicareElm.Attribute("EmployeeMaxAnnualTax").Value;

            var medicareData = new WageTaxData()
            {
                TaxRate = decimal.Parse(taxRate),
                MaxTaxedEarnings = decimal.Parse(maxTaxedEarning),
                EmployeeMaxAnnualTax = decimal.Parse(employeeMaxAnnualTax),
            };

            if (medicareData.MaxTaxedEarnings == -1)
                medicareData.MaxTaxedEarnings = decimal.MaxValue;

            if (medicareData.EmployeeMaxAnnualTax == -1)
                medicareData.EmployeeMaxAnnualTax = decimal.MaxValue;

            return new WageTax() { SocialSecurity = socialSecurityData, MediCare = medicareData };
        }

        public static WageTax GetWageTax(int year)
        {
            var wageTax = null as WageTax;
            if (_wageTaxTabel != null)
                if(_wageTaxTabel.ContainsKey(year))
                    wageTax = _wageTaxTabel[year];

            if (wageTax == null)
                throw new Exception(Error.Instance.GetError("", Error.Instance.TaxYearIsNotSupported));

            return wageTax;
        }

    }
}
 