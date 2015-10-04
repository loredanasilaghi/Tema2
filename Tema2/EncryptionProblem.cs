using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;

namespace Training
{
    [TestClass]
    public class EncryptionProblem
    {
        [TestMethod]
        public void SimpleMessage()
        {
            string originalMsg = "nicaieri nu e ca acasa";
            string expectedMsg = "nicaierinuecaacasa";
            Message encryptedMsg = EncryptMessage(originalMsg, 4);
            string decryptedMsg = DecryptMessage(encryptedMsg, 4);
            Assert.AreEqual(expectedMsg, decryptedMsg);
        }

        [TestMethod]
        public void ComplexMessage()
        {
            string originalMsg = "era mai frumos, daca nu stergeam spatiile, nu?";
            string expectedMsg = "eramaifrumosdacanustergeamspatiilenu";
            Message encryptedMsg = EncryptMessage(originalMsg, 4);
            string decryptedMsg = DecryptMessage(encryptedMsg, 4);
            Assert.AreEqual(expectedMsg, decryptedMsg);
        }

        private struct Message
        {
            public string msg;
            public int extraChar;
            public Message(string msg_var, int extrachar_var)
            {
                msg = msg_var;
                extraChar = extrachar_var;
            }
        }
       
        private static Message EncryptMessage(string message, int columns)
        {
            string shortMsg = StripPunctuationFromString(message);
            int rows = GetRowsNumber(shortMsg, columns);
            int extraLetters = (rows * columns) - shortMsg.Count();
            shortMsg += RandomString(extraLetters);
            string encryptedMessage = string.Empty;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                   encryptedMessage += shortMsg[j*rows+i];
                }
            }
            return new Message(encryptedMessage, extraLetters);
        }

        private static string DecryptMessage(Message encryptedMessage, int columns)
        {
            int rows = GetRowsNumber(encryptedMessage.msg, columns);
            
            string decryptedMessage = string.Empty;
            for(int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    decryptedMessage += encryptedMessage.msg[j * columns + i];
                }
            }
            if (encryptedMessage.extraChar != 0)
                decryptedMessage = decryptedMessage.Remove(decryptedMessage.Length - encryptedMessage.extraChar);
            return decryptedMessage;
        }

        private static int GetRowsNumber(string message, int columns)
        {
            int letters = message.Count();
            int rows = (int)Math.Ceiling((double)letters / (double)columns);
            return rows;
        }

        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            string randomString = string.Empty;
            for (int i = 0; i < length; i++)
            {
                randomString += chars[random.Next(chars.Length)];
            }
            return randomString;
        }

        private static string StripPunctuationFromString(string message)
        {
            string shortMsg = string.Empty;
            for (int i = 0; i < message.Length; i++)
            {
                if (char.IsLetterOrDigit(message[i]))
                    shortMsg += message[i];
            }
            return shortMsg;
        }
    }
}
