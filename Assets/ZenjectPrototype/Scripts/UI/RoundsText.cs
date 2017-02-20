using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZenjectPrototype.Managers;

namespace ZenjectPrototype.UI
{
    public class RoundsText : MonoBehaviour
    {
        private IRoundManager roundManager;

        public Text TextElement;
        public string Format;

        [Inject]
        public void Construct(IRoundManager roundManager)
        {
            this.roundManager = roundManager;
        }

        protected void Start()
        {
            TextElement.text = string.Format(Format, roundManager.Rounds);
        }
    }
}
