namespace RegistrationRecord.Interfaces
{
    public interface IRegistrationRecord
    {
        void AddRegistrationRecord(string registrationNumber, int YearCreated, string? VehicleId = null, decimal? cost=null);
        void AssignVehicle(string registrationNumber, string VehicleId);
        int RegistrationCount();
        int RegistrationAssignedCount();
        decimal? TotalRegistrationCost();
        string GetVehicleDetails(string registrationNumber);
        string? GetVehicleId(string registrationNumber);
    }
}
