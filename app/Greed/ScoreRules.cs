using System;
using System.Collections.Generic;

namespace Greed
{
    public abstract class AbstractScoreRules {
        public abstract int Score();
        public abstract IList<int> resetDice(IList<int> dice);

        public IList<int> RemoveThreeOf(int die, IList<int> dice) {
            IList<int> returnArray = new List<int>();

            int onesCount = 0;
            for (int ndx = 0; ndx < dice.Count; ndx++) {
                if (dice[ndx] == die) {
                    onesCount++;
                    if (onesCount > 3) {
                        returnArray.Add(dice[ndx]);
                    }
                }
                else {
                    returnArray.Add(dice[ndx]);
                }
            }

            return returnArray;
        }

        public static IList<int> RemoveOneOf(int die, IList<int> dice) {
            for (int ndx = 0; ndx < dice.Count; ndx++) {
                if (dice[ndx] == die) {
                    dice.RemoveAt(ndx);
                    return dice;
                }
            }
            throw (new Exception
                (string.Format("one die of {0} doesn't exist in array.", die)));
        }
    }

    public class NoDice : AbstractScoreRules
    {
        public override int Score() {
            return 0;
        }

        public override IList<int> resetDice(IList<int> dice) {
            return new List<int>();
        }
    }

    public class ThreeOnes : AbstractScoreRules
    {
        public override int Score() {
            return 1000;
        }

        public override IList<int> resetDice(IList<int> dice) {
            return RemoveThreeOf(1, dice);
        }

    }

    public class ThreeOfAKind : AbstractScoreRules
    {
        private int myDie;

        public ThreeOfAKind(int die) {
            myDie = die;
        }
        public override int Score() {
            return (myDie*100);
        }

        public override IList<int> resetDice(IList<int> dice) {
            return (RemoveThreeOf(myDie, dice));
        }
    }

    public class SingleOne : AbstractScoreRules
    {
        public override int Score() {
            return 100;
        }

        public override IList<int> resetDice(IList<int> dice) {
            return RemoveOneOf(1, dice);
        }
    }

    public class SingleFive: AbstractScoreRules
    {
        public override int Score() {
            return 50;
        }

        public override IList<int> resetDice(IList<int> dice) {
            return RemoveOneOf(5, dice);
        }
    }

}