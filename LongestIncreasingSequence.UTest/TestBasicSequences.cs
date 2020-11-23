using LongestIncreasingSubsequence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LongestIncreasingSequence.UTest
{
    [TestClass]
    public class TestBasicSequences
    {

        #region Recursive algorithm (forward)

        [DataRow(new int[] { }, 0)]
        [DataRow(new int[] { 7 }, 1)]
        [DataRow(new int[] { 7, 7 }, 1)]
        [DataRow(new int[] { 7, 7, 7, 7 }, 1)]
        [DataRow(new int[] { 7, 8 }, 2)]
        [DataRow(new int[] { 7, 7, 8, 8, 10, 10, 20, 20 }, 4)]
        [DataRow(new int[] { 20, 20, 10, 10, 8, 8, 7, 7 }, 1)]
        [DataRow(new int[] { 1, 3, 5, 4, 6 }, 4)]
        [DataRow(new int[] { 5, 1, 6, 7, 2, 3, 4 }, 4)]
        [DataRow(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 }, 6)]
        [DataRow(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
        [DataRow(new int[] { 0, 1, 0, 3, 2, 3, 10, 4, 14, 6, 5, 20, 8, 12, 15, 9, 9, 16, 12, 13, 9, 20 }, 11)]
        [TestMethod]
        public void Test_LISLengthRecursive_With_BasicSequences(int[] v, int expectedLISLength)
        {

            int lisLength = ClassLIS.LISLengthRecursive(v);

            Assert.AreEqual(expectedLISLength, lisLength);
        }

        #endregion

        #region Recursive algorithm (backwards)

        [DataRow(new int[] { }, 0)]
        [DataRow(new int[] { 7 }, 1)]
        [DataRow(new int[] { 7, 7 }, 1)]
        [DataRow(new int[] { 7, 7, 7, 7 }, 1)]
        [DataRow(new int[] { 7, 8 }, 2)]
        [DataRow(new int[] { 7, 7, 8, 8, 10, 10, 20, 20 }, 4)]
        [DataRow(new int[] { 20, 20, 10, 10, 8, 8, 7, 7 }, 1)]
        [DataRow(new int[] { 1, 3, 5, 4, 6 }, 4)]
        [DataRow(new int[] { 5, 1, 6, 7, 2, 3, 4 }, 4)]
        [DataRow(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 }, 6)]
        [DataRow(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
        [DataRow(new int[] { 0, 1, 0, 3, 2, 3, 10, 4, 14, 6, 5, 20, 8, 12, 15, 9, 9, 16, 12, 13, 9, 20 }, 11)]
        [TestMethod]
        public void Test_LISLengthRecursiveBackwards_With_BasicSequences(int[] v, int expectedLISLength)
        {

            int lisLength = ClassLIS.LISLengthRecursive(v);

            Assert.AreEqual(expectedLISLength, lisLength);
        }
        #endregion

        #region DP algorithm (bottom-up)

        [DataRow(new int[] { }, 0)]
        [DataRow(new int[] { 7 }, 1)]
        [DataRow(new int[] { 7, 7 }, 1)]
        [DataRow(new int[] { 7, 7, 7, 7 }, 1)]
        [DataRow(new int[] { 7, 8 }, 2)]
        [DataRow(new int[] { 7, 7, 8, 8, 10, 10, 20, 20 }, 4)]
        [DataRow(new int[] { 20, 20, 10, 10, 8, 8, 7, 7 }, 1)]
        [DataRow(new int[] { 1, 3, 5, 4, 6 }, 4)]
        [DataRow(new int[] { 5, 1, 6, 7, 2, 3, 4 }, 4)]
        [DataRow(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 }, 6)]
        [DataRow(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
        [DataRow(new int[] { 0, 1, 0, 3, 2, 3, 10, 4, 14, 6, 5, 20, 8, 12, 15, 9, 9, 16, 12, 13, 9, 20 }, 11)]
        [TestMethod]
        public void Test_LISLengthDP_With_BasicSequences(int[] v, int expectedLISLength)
        {

            int lisLength = ClassLIS.LISLengthDP(v);

            Assert.AreEqual(expectedLISLength, lisLength);
        }


        [DataRow(new int[] { 7 })]
        [DataRow(new int[] { 7, 7 })]
        [DataRow(new int[] { 7, 7, 7, 7 })]
        [DataRow(new int[] { 7, 8 })]
        [DataRow(new int[] { 7, 7, 8, 8, 10, 10, 20, 20 })]
        [DataRow(new int[] { 20, 20, 10, 10, 8, 8, 7, 7 })]
        [DataRow(new int[] { 1, 3, 5, 4, 6 })]
        [DataRow(new int[] { 5, 1, 6, 7, 2, 3, 4 })]
        [DataRow(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 })]
        [DataRow(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 })]
        [DataRow(new int[] { 0, 1, 0, 3, 2, 3, 10, 4, 14, 6, 5, 20, 8, 12, 15, 9, 9, 16, 12, 13, 9, 20 })]
        [TestMethod]
        public void Test_LISDP_With_BasicSequences_AreStrictlyIncreasing(int[] v)
        {

            int[] LIS = ClassLIS.LISDP(v);

            bool isStrictlyIncreasing = true;

            int currentMax = LIS[0];
            for (int i = 1; i < LIS.Length; i++)
            {
                if (LIS[i] > currentMax) { currentMax = LIS[i]; continue; }
                else { isStrictlyIncreasing = false; break; }
            }

            Assert.IsTrue(isStrictlyIncreasing);
        }

        [DataRow(new int[] { }, 0)]
        [DataRow(new int[] { 7 }, 1)]
        [DataRow(new int[] { 7, 7 }, 1)]
        [DataRow(new int[] { 7, 7, 7, 7 }, 1)]
        [DataRow(new int[] { 7, 8 }, 2)]
        [DataRow(new int[] { 7, 7, 8, 8, 10, 10, 20, 20 }, 4)]
        [DataRow(new int[] { 20, 20, 10, 10, 8, 8, 7, 7 }, 1)]
        [DataRow(new int[] { 1, 3, 5, 4, 6 }, 4)]
        [DataRow(new int[] { 5, 1, 6, 7, 2, 3, 4 }, 4)]
        [DataRow(new int[] { 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15 }, 6)]
        [DataRow(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 }, 4)]
        [DataRow(new int[] { 0, 1, 0, 3, 2, 3, 10, 4, 14, 6, 5, 20, 8, 12, 15, 9, 9, 16, 12, 13, 9, 20 }, 11)]
        [TestMethod]
        public void Test_LISDP_With_BasicSequences_IsLISLengthCorrect(int[] v, int expectedLISLength)
        {

            int[] LIS = ClassLIS.LISDP(v);

            Assert.AreEqual(expectedLISLength, LIS.Length);
        }

        #endregion

    }
}
