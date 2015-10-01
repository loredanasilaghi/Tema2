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
        public void TestMethod1()
        {
            string originalMsg = "nicaieri nu e ca acasa";
            string encryptedMsg = EncryptMessage(originalMsg, 4);
            string decryptedMsg = DecryptMessage(encryptedMsg, 4);
            Assert.AreEqual(originalMsg, decryptedMsg);
        }

        private static string EncryptMessage(string message, int columns)
        {
            int rows = 0;
            char[][] matrix = SetOriginalMsgIntoColumns(message, columns, ref rows);
            string encryptedMsg = string.Empty;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    encryptedMsg += matrix[j][i];
                }
            }
            return encryptedMsg;
        }

        private static string DecryptMessage(string message, int columns)
        {
            int rows = 0;
            char[][] matrix = SetEncryptedMsgIntoColumns(message, columns, ref rows);
            string decryptedMsg = string.Empty;
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    decryptedMsg += matrix[j][i];
                }
            }

            return decryptedMsg;
        }

        private static char[][] SetOriginalMsgIntoColumns(string message, int columns, ref int rows)
        {
            string shortMsg = StripPunctuationFromString(message);
            int letters = shortMsg.Count();
            rows = (int) Math.Ceiling((double)letters / (double)columns);
            int extraLetters = (rows * columns) - letters;
            shortMsg += RandomString(extraLetters);
            return CreateMatrixForEncryption(shortMsg, columns, rows);
        }

        private static char[][] SetEncryptedMsgIntoColumns(string message, int columns, ref int rows)
        {
            int letters = message.Count();
            rows = (int)Math.Ceiling((double)letters / (double)columns);
            return CreateMatrixForDecryption(message, columns, rows);
        }

        private static char[][] CreateMatrixForEncryption(string message, int columns, int rows)
        {
            char[][] matrix = new char[columns][];
            int position = 0;
            for (int i = 0; i < columns; i++)
            {
                matrix[i] = new char[rows];
                for (int j = 0; j < rows; j++)
                {
                    matrix[i][j] = message[position];
                    position++;
                }
            }
            return matrix;
        }

        private static char[][] CreateMatrixForDecryption(string message, int columns, int rows)
        {
            char[][] matrix = new char[rows][];
            int position = 0;
            for (int i = 0; i < rows; i++)
            {
                matrix[i] = new char[columns];
                for (int j = 0; j < columns; j++)
                {
                    matrix[i][j] = message[position];
                    position++;
                }
            }
            return matrix;
        }

        private static string RandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string StripPunctuationFromString(string message)
        {
            return new string(message.Where(c => (!char.IsPunctuation(c) && c!=' ')).ToArray());
        }
    }
}
