using System.Collections.Generic;
using System.Linq;

namespace Greed
{
    public class RuleEngine
    {
        public static AbstractScoreRules Create(IList<int> dice) {
            if (ContainsThreeOfAKind(1, dice)) {
                return(new ThreeOnes());
            }

            for (int die = 2; die <= 6; die++) {
                if (ContainsThreeOfAKind(die, dice)) {
                    return (new ThreeOfAKind(die));
                }
            }
            if (dice.Contains(1)) {
                return (new SingleOne());
            }

            if (dice.Contains(5)) {
                return (new SingleFive());
            }

            return new NoDice();
        }

        private static bool ContainsThreeOfAKind(int die, IList<int> dice) {
            if ((from d in dice where d == die select d).ToList().Count >= 3) {
                return true;
            }
            return false;
        }
    }
}