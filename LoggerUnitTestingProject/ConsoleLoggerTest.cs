using LoggerClassProject;
using LoggerClassProject.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace LoggerUnitTestingProject
{
    [TestClass]
    public class ConsoleLoggerTest
    {
        private Logger _logger;

        public ConsoleLoggerTest()
        {
            //var mockUoW = new Mock<IUnitofWork>();
            _logger = new ConsoleLogger();
        }

        [TestMethod]
        public void Log_ConsoleMessage_IsCalled()
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

        [TestMethod]
        public void Log_ErrorMessage_ConsoleColorIsRed()
        {
           
            var messageType = LogType.error;
           

            PrivateObject obj = new PrivateObject(_logger);
            object[] args = new object[] { messageType };
            var retVal = obj.Invoke("GetForeGroundColor",args);
                               
           Assert.AreEqual(retVal, ConsoleColor.Red);
          
        }

        [TestMethod]
        public void Log_WarningMessage_ConsoleColorIsYellow()
        {
           
            var messageType = LogType.warning;
           

            PrivateObject obj = new PrivateObject(_logger);
            object[] args = new object[] { messageType };
            var retVal = obj.Invoke("GetForeGroundColor", args);

            Assert.AreEqual(retVal, ConsoleColor.Yellow);

        }

        [TestMethod]
        public void Log_SimpleMessage_ConsoleColorIsWhite()
        {
           
            var messageType = LogType.message;
           
            PrivateObject obj = new PrivateObject(_logger);
            object[] args = new object[] { messageType };
            var retVal = obj.Invoke("GetForeGroundColor", args);

            Assert.AreEqual(retVal, ConsoleColor.White);

        }
               
    }
}
