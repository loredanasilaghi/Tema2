using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tema2
{
    [TestClass]
    public class LotoProblem
    {
        [TestMethod]
        public void TestTheChancesToGet6LuckyNumbers()
        {
            int totalBalls = 49;
            int obtainedBalls = 6;
            int extractedBalls = 6;
            Assert.AreEqual(0.00000007, CalculateWinningProbability(totalBalls, obtainedBalls, extractedBalls));
        }

        [TestMethod]
        public void TestTheChancesToGet5LuckyNumbers()
        {
            int totalBalls = 49;
            int obtainedBalls = 5;
            int extractedBalls = 6;
            Assert.AreEqual(0.00001845, CalculateWinningProbability(totalBalls, obtainedBalls, extractedBalls));
        }

        [TestMethod]
        public void TestTheChancesToGet4LuckyNumbers()
        {
            int totalBalls = 49;
            int obtainedBalls = 4;
            int extractedBalls = 6;
            Assert.AreEqual(0.00096862, CalculateWinningProbability(totalBalls, obtainedBalls, extractedBalls));
        }

        private double CalculateFactorial(int noToBeFactored)
        {
            if (noToBeFactored == 0)
            {
                return 1;
            }

            double multiplication = 1;
            for (int i = 1; i <= noToBeFactored; i++)
            {
                multiplication *= (double)i;
            }
            
            return multiplication;
        }

        private double CalculateCombinations(int n, int k)
        {
            double result = CalculateFactorial(n) / (CalculateFactorial(k) * CalculateFactorial(n - k));
            return result;
        }

        private double CalculateWinningProbability(int totalBalls, int obtainedBalls, int extractedBalls)
        {
            int unextractedBalls = totalBalls - extractedBalls;
            //double a = CalculateCombinations(extractedBalls, obtainedBalls);
            //double b = CalculateCombinations(unextractedBalls, extractedBalls - obtainedBalls);
            //double c = CalculateCombinations(totalBalls, extractedBalls);
            double probability = (CalculateCombinations(extractedBalls, obtainedBalls) *
                                    CalculateCombinations(unextractedBalls, extractedBalls - obtainedBalls)) /
                                    CalculateCombinations(totalBalls, extractedBalls);
            //double aux = a * b;
            //double prob = Math.Round(aux / c, 8);
            //return prob;
            return Math.Round(probability, 8);
        }
    }
}
