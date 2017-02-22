using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using ZenjectPrototype.ResourceSystem;

namespace ZenjectPrototype.UI
{
    public class ResourceText : MonoBehaviour
    {
        [SerializeField]
        private Text TextElement;
        [SerializeField]
        private string TextFormat;
        private IResource<int> resource;

        [Inject]
        public void Construct(IResource<int> resource)
        {
            this.resource = resource;
        }

        protected void Start()
        {
            resource.OnStockChanged += Resource_OnStockChanged;
            UpdateText();
        }

        private void Resource_OnStockChanged(object sender, EventArgs e)
        {
            UpdateText();
        }

        private void UpdateText()
        {
            TextElement.text = string.Format(TextFormat, resource.Stock);
        }
    }
}
