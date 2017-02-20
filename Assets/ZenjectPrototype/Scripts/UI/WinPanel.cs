using UnityEngine;
using System.Collections;
using ZenjectPrototype.GameState;
using Zenject;

namespace ZenjectPrototype.UI
{
	/// <summary>
	/// Description missing
	/// </summary>
	public class WinPanel : MonoBehaviour
    {
        private ICondition condition;

        public GameObject Container;

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
            Container.SetActive(true);
        }
    }
}