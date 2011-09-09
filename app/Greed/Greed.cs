using System.Collections;
using System.Collections.Generic;

namespace Greed
{
    public static class Greed
    {
        public static int Score(IList<int> dice) {
            int returnScore = 0;
            while (dice.Count > 0) {
                AbstractScoreRules ruleEngine = RuleEngine.Create(dice);
                returnScore += ruleEngine.Score();

                dice = ruleEngine.resetDice(dice);
            }
            return returnScore;
        }
    }
}
