using UnityEngine;
using Zenject;

namespace ZenjectPrototype.UI
{
    /// <summary>
    /// Changes visiblity of a GameObject when given condition is met.
    /// </summary>
    public class VisibilityCondition : MonoBehaviour
    {
        private ICondition condition;

        [SerializeField]
        private GameObject TargetGameObject;
        [SerializeField]
        public bool VisiblityOnceConditionMet;

        [Inject]
        public void Construct(ICondition condition)
        {
            this.condition = condition;
        }

        protected void Awake()
        {
            condition.OnConditionMet += Condition_OnConditionMet;
        }

        private void Condition_OnConditionMet(object sender, System.EventArgs e)
        {
            TargetGameObject.SetActive(VisiblityOnceConditionMet);
        }
    }
}