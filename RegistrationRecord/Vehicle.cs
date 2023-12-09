using RegistrationRecord.Interfaces;

namespace RegistrationRecord
{
    internal class Vehicle : IVehicle
    {

        #region "static"
        public static IVehicle CreateInstance(string vehicleId)
        {
            if (string.IsNullOrWhiteSpace(vehicleId))
            {
                throw new ArgumentException("Vehicle Id must be supplied");
            }
            if (!int.TryParse(vehicleId, out _) || vehicleId.Length != 5)
            {
                throw new ArgumentException("Vehicle Id must be 5 characters numeric");
            }
            return new Vehicle(vehicleId);
        }

        #endregion

        #region "constructor"

        internal Vehicle(string vehicleId)
        {
            VehicleId = vehicleId;
        }

        #endregion

        #region "IVehicle"
        public string VehicleId { get; }
        #endregion
    }
}
