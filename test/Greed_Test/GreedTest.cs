using System.Collections.Generic;
using NUnit.Framework;

namespace Greed_Test
{
    [TestFixture]
    public class GreedTest
    {

        [Test]
        public void When_A_Single_One_Then_Scorer_Returns_100() {
            IList<int> dice = new List<int>() {1};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(100, score);
        }

        [Test]
        public void When_A_Single_Five_Then_Scorer_Returns_50() {
            IList<int> dice = new List<int>() {5 };
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(50, score);
        }

        [Test]
        public void When_3_Ones_Then_Scorer_Returns_1000() {
            IList<int> dice = new List<int>(){1,1,1};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(1000, score);
        }

        [Test]
        public void When_4_Ones_Then_Scorer_Returns_1100() {
            IList<int> dice = new List<int>() {1,1,1,1};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(1100, score);
        }
        [Test]
        public void When_2_Ones_Then_Scorer_Returns_200() {
            IList<int> dice = new List<int>() {1,1};

            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(200, score);
        }

        [Test, Sequential]
        public void When_3_Of_Any_Number_Except_One_Then_Scorer_Returns_100_Times_number(
            [Values(2, 3,4,5,6)] int die, 
            [Values(200, 300, 400, 500, 600)] int expected_score ) {

            IList<int> dice = new List<int>() {die, die, die};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(expected_score, score);
        }

        [Test]
        public void Array_11123() {
            IList<int> dice = new List<int>() {1,1,1,2,3};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(1000, score);
        }

        [Test]
        public void Array_11115() {
            IList<int> dice = new List<int>() {1,1,1,1,5};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(1150, score);
        }

        [Test]
        public void Array_11111() {
            IList<int> dice = new List<int>() {1,1,1,1,1};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(1200, score);
        }

        [Test]
        public void Array_23462() {
            IList<int> dice = new List<int>() {2,3,4,6,2};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(0, score);
        }

        [Test]
        public void Array_34533() {
            IList<int> dice = new List<int>() {3,4,5,3,3};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(350, score);
        }

        [Test]
        public void Array_15124() {
            IList<int> dice = new List<int>() {1,5,1,2,4};
            int score = Greed.Greed.Score(dice);
            Assert.AreEqual(250, score);
        }
    }
}
