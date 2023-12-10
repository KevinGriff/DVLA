using RegistrationRecord.Interfaces;

namespace TestRegistrationRecord
{
    [TestClass]
    public class UnitTest_bulk   {

        static IRegistrationRecord? _largeRecord;
        
        [ClassInitialize()]
        public static void ClassInitialize(TestContext tc)
        {
            _largeRecord = GetLargeRecord();
        }

        [TestMethod]
        public void TestLargeRegistrationCount()
        {
            Assert.AreEqual(_largeRecord?.RegistrationCount(), 10000);
        }


        [TestMethod]
        public void TestLargeRegistrationFound()
        {
            Assert.AreEqual(_largeRecord?.GetVehicleId("675"), "12345");
        }


        private static IRegistrationRecord GetLargeRecord()
        {
            var record = RegistrationStore.CreateInstance();

            for (int i = 0; i < 10000; i++)
            {
                record.AddRegistrationRecord(i.ToString(), 2001, "12345");
            }
            return record;
        }
    }
}