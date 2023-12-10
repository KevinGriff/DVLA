namespace RegistrationRecord.Interfaces
{
    internal interface IRegistration
    {
        string RegistrationNumber { get; }
        int YearCreated { get; }

        bool MatchRegistration(string registrationNumber);
    }
}
