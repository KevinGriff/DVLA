using RegistrationRecord.Interfaces;

namespace RegistrationRecord
{
    public class RegistrationStore : IRegistrationRecord
    {
        readonly Dictionary<IRegistration, IVehicle?> RecordStore = new();

        public static IRegistrationRecord CreateInstance() { return new RegistrationStore(); }

        #region "IRegistrationRecord"
       
        public int RegistrationCount()
        {
            return RecordStore?.Count ?? 0;
        }

        public string GetVehicleDetails(string registrationNumber)
        {
            var reg = GetRegistration(registrationNumber);
            if (reg == null)
            {
                return $"No record found for registration number '{registrationNumber}'";
            }

            var vehicle = GetVehicle(reg);
            if (vehicle == null)
            {
                return $"Registration number '{registrationNumber}' not assigned to a vehicle";
            }

            return $"Registration number '{registrationNumber}' assigned to vehicle '{vehicle?.VehicleId}'";
        }

        public string? GetVehicleId(string registrationNumber)
        {
            var reg = GetRegistration(registrationNumber);
            if (reg == null)
            {
                return null;
            }

            return GetVehicle(reg)?.VehicleId;

        }
        public void AddRegistrationRecord(string registrationNumber, int YearCreated, string? VehicleId = null)
        {
            if (GetRegistration(registrationNumber) != null)
            {
                throw new InvalidDataException($"Record already exists for registration '{registrationNumber}'");
            }
            var reg = Registration.CreateInstance(registrationNumber, YearCreated);
            IVehicle? vehicle = null;
            if (VehicleId != null)
            {
                vehicle = Vehicle.CreateInstance(VehicleId);
            }
            AddToRecord(reg, vehicle);
        }

        #endregion

        private void AddToRecord(IRegistration reg, IVehicle? vehicle)
        {
            RecordStore.Add(reg, vehicle);
        }
        private IRegistration? GetRegistration(string registrationNumber)
        {
            var reg = RecordStore.Keys.Where(r => r.MatchRegistration(registrationNumber));
            if (!(reg?.Any() ?? false))
            {
                return null;
            }
            if (reg.Count() > 1)
            {
                throw new InvalidDataException($"Multiple records for registration '{registrationNumber}'");
            }
            return reg.First();
        }

        private IVehicle? GetVehicle(IRegistration registration)
        {
            RecordStore.TryGetValue(registration, out IVehicle? vehicle);
           
            return vehicle;
         }

    }
}