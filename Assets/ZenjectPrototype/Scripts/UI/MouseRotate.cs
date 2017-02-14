using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;
using ZenjectPrototype.Entities.Capabilities;

namespace ZenjectPrototype.UI
{
    public class MouseRotate : MonoBehaviour
    {
        private IRotatable rotatable;
        private bool rotate = false;

        [Inject]
        public void Construct(IRotatable rotatable)
        {
            this.rotatable = rotatable;
        }

        protected void OnMouseDown()
        {
            rotate = true;
        }

        protected void OnMouseUp()
        {
            rotate = false;
        }

        private void Update()
        {
            if(rotate)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    rotatable.LookAt(hit.point);
                }
            }
        }
    }
}
