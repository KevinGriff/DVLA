using RegistrationRecord.Interfaces;

namespace RegistrationRecord
{
    internal class Vehicle : IVehicle
    {

        #region "static"
        public static IVehicle CreateInstance(string vehicleId)
        {
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
