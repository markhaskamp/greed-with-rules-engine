using System;
using System.Collections.Generic;

namespace Greed
{
    public abstract class AbstractScoreRules {
        public abstract int Score();
        public abstract IList<int> resetDice(IList<int> dice);

        public IList<int> RemoveThreeOf(int die, IList<int> dice) {
            for (int i = 0; i < 3; i++) {
                dice.Remove(die);
            }

            return (dice);
        }

        public static IList<int> RemoveOneOf(int die, IList<int> dice) {
            dice.Remove(die);
            return dice;
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