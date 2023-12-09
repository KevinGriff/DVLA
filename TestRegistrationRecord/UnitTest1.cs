using RegistrationRecord.Interfaces;

namespace TestRegistrationRecord
{
    [TestClass]
    public class UnitTest1
    {

        static IRegistrationRecord _largeRecord; // = GetLargeRecord();

        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
          _largeRecord = GetLargeRecord();
        }

            [TestMethod]
        public void TestRegistrationCount()
        {
            Assert.AreEqual(GetRecord().RegistrationCount(), 3);
        }

        [TestMethod]
        public void TestLargeRegistrationCount()
        {
            Assert.AreEqual(_largeRecord.RegistrationCount(), 10000);
        }

        [TestMethod]
        public void TestRegistrationFound()
        {
            Assert.AreEqual(GetRecord().VehicleId("FG02 HJK"), "67890");
        }

        [TestMethod]
        public void TestLargeRegistrationFound()
        {
            Assert.AreEqual(_largeRecord.VehicleId("675"), "12345");
        }

        [TestMethod]
        public void TestRegistrationFound_NoVehicle()
        {
            Assert.IsNull(GetRecord().VehicleId("L33T H4X0R"));
        }

        [TestMethod]
        public void TestRegistrationNotFound()
        {
            Assert.IsNull(GetRecord().VehicleId("FG02 XXX"));
        }

        private static IRegistrationRecord GetRecord()
        {
            var record = RegistrationStore.CreateInstance();
            record.AddRegistrationRecord("AB01 CDE", 2001, "12345");
            record.AddRegistrationRecord("FG02 HJK", 2002, "67890");
            record.AddRegistrationRecord("L33T H4X0R", 2022);
            return record;
        }

        private static IRegistrationRecord GetLargeRecord()
        {
            var record = RegistrationStore.CreateInstance();

            for (int i = 0; i<10000; i++)
            {
                record.AddRegistrationRecord(i.ToString(), 2001, "12345");
            }
            return record;
        }
    }
}