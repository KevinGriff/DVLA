using RegistrationRecord.Interfaces;

namespace RegistrationRecord
{
    internal class Registration : IRegistration
    {

        #region "static"

        const int MaxYearRange = 50;
        public static IRegistration CreateInstance(string registrationNumber, int year)
        {

            if (string.IsNullOrWhiteSpace(registrationNumber))
            {
                throw new ArgumentException("Registration Number must be supplied");
            }
            // could also check against regex - or an external service?
            if (year > DateTime.Today.Year || year < DateTime.Today.Year - MaxYearRange)
            {
                throw new ArgumentException("Year of Registration out of range");
            }

            return new Registration(registrationNumber, year);
        }

        #endregion

        #region "constructor"

        internal Registration(string registrationNumber, int year)
        {
            RegistrationNumber = registrationNumber;
            YearCreated = year;
        }

        #endregion

        #region "IRegistration"

        public string RegistrationNumber { get; }
        public int YearCreated { get; }

        public bool MatchRegistration(string registrationNumber)
        {
            if (string.IsNullOrEmpty(registrationNumber)) return false;
            registrationNumber = RemoveWhitespace(registrationNumber);

            return (string.Equals(registrationNumber, RegistrationKey, StringComparison.OrdinalIgnoreCase));
        }
        #endregion

        private string RegistrationKey
        {
            get { return RemoveWhitespace(RegistrationNumber); }

        }
        private static string RemoveWhitespace(string inStr)
        {
            return new string(inStr.Where(c => !char.IsWhiteSpace(c)).ToArray());
        }
    }
}
