
using RegistrationRecord;

internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            var record = RegistrationStore.CreateInstance();
            record.AddRegistrationRecord("AB01 CDE", 2001, "12345");
            // record.AddRegistrationRecord("AB01cde", 2001, "12345");
            record.AddRegistrationRecord("FG02 HJK", 2002, "67890");
            record.AddRegistrationRecord("L33T H4X0R", 2022);

            Console.WriteLine($"There are {record.RegistrationCount()} entries in the registration record");

            var registrationNumber = "FG02 HJK";
            var vehicleId = record.GetVehicleId(registrationNumber);
            Console.WriteLine($"Registration number '{registrationNumber}' assigned to vehicle '{vehicleId}'");

            registrationNumber = "L33T H4X0R";
            vehicleId = record.GetVehicleId(registrationNumber);
            Console.WriteLine($"Registration number '{registrationNumber}' assigned to vehicle '{vehicleId}'");

                //registrationNumber = "AB01 CDE";
                //var details = record.GetVehicleDetails(registrationNumber);
                //Console.WriteLine(details);


        }
        catch (Exception ex)
        {
            Console.WriteLine($"Processing failed: {ex.Message}");
        }

    }
}

