namespace RegistrationRecord.Interfaces
{
    internal interface IRegistration
    {
        string RegistrationNumber { get; }
        int YearCreated { get; }
        decimal? Cost { get; }
        bool MatchRegistration(string registrationNumber);
    }
}
