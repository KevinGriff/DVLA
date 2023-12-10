
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

            var details = record.GetVehicleDetails("AB01 CDE");

            Console.WriteLine(details);

            Console.WriteLine($"There are {record.RegistrationCount()} entries in the registration record");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Processing failed: {ex.Message}");
        }

    }
}

