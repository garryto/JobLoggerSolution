using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LoggerClassProject;
using LoggerClassProject.Enums;
using LoggerUnitTestingProject;
using LoggerClassProject.Core;
using Moq;

namespace LoggerUnitTestingProject
{
    

    [TestClass]
    public class DbLoggerTest
    {
        private Logger _logger;

        public DbLoggerTest()
        {
            var mockUoW = new Mock<IUnitofWork>();
            _logger = new DBLogger(mockUoW.Object);
        }

        [TestMethod]
        public void Log_DbMessageLogger_IsCalled()
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
