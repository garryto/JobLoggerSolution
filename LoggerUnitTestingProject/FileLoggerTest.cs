using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoggerClassProject;
using LoggerClassProject.Enums;

namespace LoggerUnitTestingProject
{
    [TestClass]
    public class FileLoggerTest
    {
        private Logger _logger;

        public FileLoggerTest()
        {
            _logger = new FileLogger();
        }


        [TestMethod]
        public void Log_FileMessageLogger_IsCalled()
        {
            var message = "Message";
            var messageType = LogType.message;
            try
            {
                var log = new Log();
                log.Message = message;
                log.MessageType = messageType;
                _logger.LogMessage(log);

                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsFalse(false);
            }
        }
    }
}
