using EFW2C.RecordEFW2C.W2cDocument;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test.Testing
{
    public class DocumentDataTest
    {
        private static readonly Random random = new Random();

        private static readonly string[] commonNames =
        {
            "Emma", "Liam", "Olivia", "Noah", "Ava", "Isabella", "Sophia", "Jackson", "Mia", "Lucas",
            "Oliver", "Aiden", "Charlotte", "Amelia", "Evelyn", "Abigail", "Harper", "Isaac", "James", "Benjamin",
            "Henry", "Michael", "Ella", "Alexander", "Daniel", "Matthew", "Aria", "Grace", "Scarlett", "Leo",
            "Chloe", "Zoe", "Lily", "Riley", "Layla", "Madison", "Ethan", "Sebastian", "Caleb", "Wyatt",
            "Nora", "Hazel", "Mila", "Aubrey", "Luna", "Sofia", "Ellie", "Avery", "Liam", "Grace",
            "Elijah", "Amelia", "Aiden", "Lucy", "Harper", "Mason", "Addison", "Aria", "Ella", "Scarlett",
            "Aria", "Zoe", "Nora", "Penelope", "Eleanor", "Aurora", "Scarlett", "Amelia", "Chloe", "Liam",
            "Jackson", "Emma", "Olivia", "Sophia", "Ava", "Mia", "Isabella", "Sophia", "Jackson", "Oliver",
            "Aiden", "Lucas", "Ethan", "Alexander", "Henry", "Joseph", "Benjamin", "Samuel", "Sebastian", "Daniel"
        };

        private static readonly string[] stateAbbreviations =
            {
                "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "FL", "GA",
                "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD",
                "MA", "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ",
                "NM", "NY", "NC", "ND", "OH", "OK", "OR", "PA", "RI", "SC",
                "SD", "TN", "TX", "UT", "VT", "VA", "WA", "WV", "WI", "WY"
            };

        private static readonly string[] streetNames =
        {
            "Maple", "Oak", "Cedar", "Pine", "Elm", "Birch", "Willow", "Hill", "Meadow", "Lake",
            // Add more street names as needed
        };

        private static readonly string[] cities =
        {
            "New York", "Los Angeles", "Chicago", "Houston", "Phoenix", "Philadelphia", "San Antonio", "San Diego", "Dallas", "San Jose",
            "Austin", "Jacksonville", "Fort Worth", "Columbus", "San Francisco", "Charlotte", "Indianapolis", "Seattle", "Denver", "Washington",
            "Boston", "El Paso", "Nashville", "Portland", "Oklahoma City", "Las Vegas", "Detroit", "Memphis", "Louisville", "Baltimore",
            "Milwaukee", "Albuquerque", "Tucson", "Fresno", "Sacramento", "Mesa", "Kansas City", "Atlanta", "Long Beach", "Colorado Springs",
            "Raleigh", "Miami", "Virginia Beach", "Omaha", "Oakland", "Minneapolis", "Tulsa", "Arlington", "New Orleans", "Wichita",
            "Cleveland", "Tampa", "Bakersfield", "Aurora", "Anaheim", "Honolulu", "Santa Ana", "Riverside", "Corpus Christi", "Lexington",
            "Stockton", "Henderson", "Saint Paul", "St Louis", "Cincinnati", "Pittsburgh", "Greensboro", "Anchorage", "Plano", "Lincoln",
            "Orlando", "Irvine", "Newark", "Durham", "Chula Vista", "Toledo", "Fort Wayne", "St Petersburg", "Laredo", "Jersey City",
            "Chandler", "Madison", "Lubbock", "Buffalo", "Laredo", "Irving", "Scottsdale", "Gilbert", "Fremont", "San Bernardino"
        };

        public static string GenerateRandomAddress()
        {
            string street = $"{random.Next(1, 1000)} {streetNames[random.Next(streetNames.Length)]} St";
            string city = cities[random.Next(cities.Length)];
            string state = stateAbbreviations[random.Next(stateAbbreviations.Length)];
            string zipCode = random.Next(10000, 100000).ToString();

            string fullAddress = $"{street}, {city}, {state} {zipCode}";

            // Ensure that the result does not exceed 22 characters
            if (fullAddress.Length > 22)
            {
                fullAddress = fullAddress.Substring(0, 22);
            }

            return fullAddress;
        }
        public static string GenerateRandomStateAbbreviation()
        {
            int index = random.Next(stateAbbreviations.Length);
            return stateAbbreviations[index];
        }

        public static string GenerateRandomName()
        {
            int index = random.Next(commonNames.Length);
            return commonNames[index];
        }

        public static string GenerateRandomEIN()
        {
            // Generate random digits
            int[] digits = new int[9];
            for (int i = 0; i < 9; i++)
            {
                digits[i] = random.Next(10);
            }

            // Format as EIN
            string ein = $"{digits[0]}{digits[1]}-{digits[2]}{digits[3]}{digits[4]}{digits[5]}{digits[6]}{digits[7]}{digits[8]}";

            // Check if EIN starts with any of the excluded prefixes
            string[] excludedPrefixes = { "07", "08", "09", "17", "18", "19", "28", "29", "49", "69", "70", "78", "79", "89" };
            while (excludedPrefixes.Any(prefix => ein.StartsWith(prefix)))
            {
                // If the generated EIN starts with an excluded prefix, generate a new set of digits
                for (int i = 0; i < 9; i++)
                {
                    digits[i] = random.Next(10);
                }

                // Format as EIN
                ein = $"{digits[0]}{digits[1]}-{digits[2]}{digits[3]}{digits[4]}{digits[5]}{digits[6]}{digits[7]}{digits[8]}";
            }

            return ein;
        }

        public static string GenerateRandomUserID()
        {
            // Assuming an 8-digit user ID for example
            int userId = random.Next(10000000, 99999999);
            return userId.ToString();
        }

        public static string GenerateRandomZipCode()
        {
            return random.Next(10000, 99999).ToString();
        }

        public static string GenerateRandomZipCodeExt()
        {
            return random.Next(1000, 9999).ToString();
        }

        private static string GenerateRandomCity()
        {
            return cities[random.Next(cities.Length)];
        }

        public static string GenerateRandomDoubleAsString()
        {
            int precision = random.Next(3); // Randomly choose precision: 0, 1, or 2 decimal places
            int integerPart = random.Next(5000); // Limit to a maximum of 5000

            double generatedDouble = integerPart / Math.Pow(10, precision);
            double roundedDouble = Math.Round(generatedDouble, precision);

            return roundedDouble.ToString("F" + precision);
        }

        public static string GenerateRandomSSN()
        {
            int areaNumber;
            int groupNumber;
            int serialNumber;

            do
            {
                areaNumber = random.Next(100, 1000);
                groupNumber = random.Next(10, 100);
                serialNumber = random.Next(1000, 10000);
            } while (areaNumber.ToString().StartsWith("9") || areaNumber.ToString().StartsWith("666"));

            return $"{areaNumber:D3}-{groupNumber:D2}-{serialNumber:D4}";
        }
        public static string GenerateRandomUSAPhoneNumber()
        {
            string[] formats = { "XXX-XXX-XXXX", "(XXX) XXX-XXXX" };
            string selectedFormat = formats[random.Next(formats.Length)];

            string phoneNumber = "";

            foreach (char formatChar in selectedFormat)
            {
                if (formatChar == 'X')
                {
                    phoneNumber += random.Next(10).ToString();
                }
                else
                {
                    phoneNumber += formatChar;
                }
            }

            return phoneNumber;
        }

        public static string GenerateRandomEmail()
        {
            string[] domains = { "hotmail.com", "outlook.com", "yahoo.com", "gmail.com" };
            string selectedDomain = domains[random.Next(domains.Length)];

            return $"{GenerateRandomName().ToLower()}@{selectedDomain}";
        }

        public static string GetRandomPreparerCode()
        {
            char[] codes = { 'A', 'L', 'S', 'P', 'O' };

            // Seed the random number generator (optional)
            Random random = new Random();

            // Get a random index from the array
            int randomIndex = random.Next(codes.Length);

            // Return the character at the random index
            return codes[randomIndex].ToString();
        }

        static string GetRandomKindOfEmployer()
        {
            char[] values = { 'F', 'S', 'T', 'Y', 'N' };

            // Seed the random number generator (optional)
            Random random = new Random();

            // Get a random index from the array
            int randomIndex = random.Next(values.Length);

            // Return the character at the random index as a string
            return values[randomIndex].ToString();
        }

        static string GenerateRandomTaxYear()
        {
            // Seed the random number generator (optional)
            Random random = new Random();

            // Generate a random tax year between 2020 and 2023
            int randomYear = random.Next(2020, 2024);

            return randomYear.ToString();
        }
        public static W2cSubmitter CreateSubmitterData(W2cDocument document)
        {
            var submitter = new W2cSubmitter(document);

            submitter.EinSubmitter = GenerateRandomEIN();
            submitter.SoftwareCode = int.Parse(submitter.EinSubmitter[0].ToString()) > 5 ? "99" : "98";
            submitter.UserIdentification = GenerateRandomUserID();
            submitter.SoftwareVendorCode = submitter.SoftwareCode == "99" ? "4444" : "" ;
            submitter.SubmitterName = GenerateRandomName();
            submitter.ContactName = GenerateRandomName();
            submitter.ZipCode = GenerateRandomZipCode();
            submitter.ZipCodeExtension = GenerateRandomZipCodeExt();
            submitter.StateAbbreviation = GenerateRandomStateAbbreviation();
            submitter.LocationAddress = GenerateRandomAddress();
            submitter.DeliveryAddress = GenerateRandomAddress();
            submitter.City = GenerateRandomCity();  
            submitter.ForeignPostalCode = "BOX 300";
            submitter.ContactPhone = GenerateRandomUSAPhoneNumber();
            submitter.ContactPhoneExtension = "108";
            submitter.ContactEMailInternet = GenerateRandomEmail();
            submitter.ContactFax = GenerateRandomUSAPhoneNumber();
            submitter.PreparerCode = GetRandomPreparerCode();
            submitter.ResubIndicator = "0";

            return submitter;
        }

        internal static W2cEmployee CreateEmployeeRandomly(W2cDocument document)
        {
            var employee = new W2cEmployee(document);

            employee.ZipCode = GenerateRandomZipCode();
            employee.ZipCodeExtension = GenerateRandomZipCodeExt();
            employee.StateAbbreviation = GenerateRandomStateAbbreviation();
            employee.LocationAddress = GenerateRandomAddress();
            employee.DeliveryAddress = GenerateRandomAddress();
            employee.City = GenerateRandomCity();
            employee.ForeignPostalCode = "BOX 300";
            employee.SocialSecurityNumberCorrect = GenerateRandomSSN();
            employee.SocialSecurityNumberOriginal = GenerateRandomSSN();
            employee.SocialSecurityTaxWithheldCorrect = GenerateRandomDoubleAsString();
            employee.SocialSecurityTaxWithheldOriginal = GenerateRandomDoubleAsString();
            employee.EmployeeFirstNameOriginal = GenerateRandomName();
            employee.EmployeeFirstNameCorrect = GenerateRandomName();
            employee.EmployeeLastNameCorrect = GenerateRandomName();
            employee.EmployeeLastNameOriginal = GenerateRandomName();

            return employee;
        }
        internal static W2cEmployeeOptional CreateEmployeeOptionalRandomly(W2cDocument document)
        {
            var employeeOptional = new W2cEmployeeOptional(document);

            employeeOptional.AllocatedTipsCorrect = GenerateRandomDoubleAsString();
            employeeOptional.AllocatedTipsOriginal = GenerateRandomDoubleAsString();

            return employeeOptional;
        }
        internal static W2cEmployer CreateEmployerRandomly(W2cDocument document)
        {
            var employer = new W2cEmployer(document);

            employer.TaxYear = GenerateRandomTaxYear();
            employer.KindOfEmployer = GetRandomKindOfEmployer();
            employer.AgentIndicator = "1";
            employer.EinAgentFederal = GenerateRandomEIN();
            employer.EinAgent = GenerateRandomEIN();
            employer.EmployerName = GenerateRandomName();

            return employer;
        }

        public static W2cEmployeeStateTotal CreateEmployeeStateTotal(W2cDocument document)
        {
            var employeeStateTotal = new W2cEmployeeStateTotal(document);
            employeeStateTotal.SupplementalData = " this is data from user";

            return employeeStateTotal;
        }

        public static W2cEmployeeState CreateEmployeeState(W2cDocument document)
        {
            var employeeState = new W2cEmployeeState(document);

            employeeState.City = GenerateRandomCity();
            employeeState.DateFirstEmployedCorrect = GenerateRandomDoubleAsString();
            employeeState.DateFirstEmployedOriginal = GenerateRandomDoubleAsString();

            return employeeState;
        }

        public static void FillData(W2cDocument document)
        {
            var submitter = CreateSubmitterData(document);

            document.SetSubmitter(submitter);

            for (int i = 0; i < 5; i++)
            {
                var employer = CreateEmployerRandomly(document);

                for (int j = 0; j < 7; j++)
                {
                    var employee = CreateEmployeeRandomly(document);

                    var employeeOptional = CreateEmployeeOptionalRandomly(document);

                    employee.SetEmployeeOptional(employeeOptional);

                    var employeeState = CreateEmployeeState(document);

                    employee.SetEmployeeState(employeeState);

                    var employeeStateTotal = CreateEmployeeStateTotal(document);

                    employer.SetEmployeeStateTotal(employeeStateTotal);

                    employer.AddEmployee(employee);
                }

                document.AddEmployer(employer);
            }
        }
    }
}
