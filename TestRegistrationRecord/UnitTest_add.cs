using RegistrationRecord.Interfaces;

namespace TestRegistrationRecord
{
    [TestClass]
    public class UnitTest_add
    {

        static IRegistrationRecord? _record;

        [TestMethod]
        public void TestRegistrationAdd()
        {
            _record = RegistrationStore.CreateInstance();
            _record?.AddRegistrationRecord("AB01 CDE", 2001, "12345");
            Assert.AreEqual(_record?.RegistrationCount(), 1);
        }

        [TestMethod]
        public void TestRegistrationAddDuplicate()
        {
            _record = RegistrationStore.CreateInstance();
            _record?.AddRegistrationRecord("AB01 CDE", 2001, "12345");

            Assert.ThrowsException<ArgumentException>(() => _record?.AddRegistrationRecord("AB01 CDE", 2001, "12345"));
        }

        [TestMethod]
        public void TestRegistrationAddFuture()
        {
            _record = RegistrationStore.CreateInstance();
            Assert.ThrowsException<ArgumentException>(() => _record?.AddRegistrationRecord("AB01 CDE", DateTime.Today.Year + 1, "12345"));
        }

        [TestMethod]
        public void TestRegistrationAddOld()
        {
            _record = RegistrationStore.CreateInstance();
            Assert.ThrowsException<ArgumentException>(() => _record?.AddRegistrationRecord("AB01 CDE", DateTime.Today.Year - 60, "12345"));


        }
        [TestMethod]
        public void TestRegistrationAddEmpty()
        {
            _record = RegistrationStore.CreateInstance();
            Assert.ThrowsException<ArgumentException>(() => _record?.AddRegistrationRecord(string.Empty, DateTime.Today.Year, "12345"));
        }

    }
}