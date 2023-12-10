using RegistrationRecord.Interfaces;

namespace TestRegistrationRecord
{
    [TestClass]
    public class UnitTest1
    {

        static IRegistrationRecord? _record;

        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            _record = GetRecord();
        }

        [TestMethod]
        public void TestRegistrationCount()
        {
            Assert.AreEqual(_record?.RegistrationCount(), 3);
        }
        [TestMethod]
        public void TestRegistrationCount_none()
        {
            var record = RegistrationStore.CreateInstance();
            Assert.AreEqual(record?.RegistrationCount(), 0);
        }

        [TestMethod]
        public void TestRegistrationFound()
        {
            Assert.AreEqual(_record?.GetVehicleId("FG02 HJK"), "67890");
        }

        [TestMethod]
        public void TestRegistrationFound_NoVehicle()
        {
            Assert.IsNull(_record?.GetVehicleId("L33T H4X0R"));
        }

        [TestMethod]
        public void TestRegistrationNotFound()
        {
            Assert.IsNull(_record?.GetVehicleId("FG02 XXX"));
        }

        private static IRegistrationRecord GetRecord()
        {
            var record = RegistrationStore.CreateInstance();
            record.AddRegistrationRecord("AB01 CDE", 2001, "12345");
            record.AddRegistrationRecord("FG02 HJK", 2002, "67890");
            record.AddRegistrationRecord("L33T H4X0R", 2022);
            return record;
        }

    }
}