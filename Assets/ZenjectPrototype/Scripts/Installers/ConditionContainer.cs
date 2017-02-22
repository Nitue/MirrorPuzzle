using Zenject;

namespace ZenjectPrototype.Installers
{
    public class ConditionContainer
    {
        public ICondition WinCondition;
        public ICondition LoseCondition;

        public ConditionContainer(
            [Inject(Id = Condition.Win)] ICondition winCondition,
            [Inject(Id = Condition.Lose)] ICondition loseCondition)
        {
            WinCondition = winCondition;
            LoseCondition = loseCondition;
        }

        public enum Condition
        {
            Win,
            Lose
        }
    }
}
