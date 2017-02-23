using Zenject;

namespace ZenjectPrototype.Installers
{
    /// <summary>
    /// Instance of this class can be used to get a specific Condition by using FromResolveGetter when binding.
    /// </summary>
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
