using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DVLA_UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRegistrationCount()
        {
            var record = RegistrationRecord.RegistrationRecord.CreateInstance();
            record.AddRegistrationRecord("AB01 CDE", 2001, "12345");
            record.AddRegistrationRecord("FG02 HJK", 2002, "67890");
            record.AddRegistrationRecord("L33T H4X0R", 2022);


        }
    }
}
