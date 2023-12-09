namespace RegistrationRecord.Interfaces
{
    public interface IRegistrationRecord
    {
        void AddRegistrationRecord(string registrationNumber, int YearCreated, string? VehicleId = null);
        int RegistrationCount();
        string GetVehicleDetails(string registrationNumber);
        string? VehicleId(string registrationNumber);
    }
}
