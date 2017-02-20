using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZenjectPrototype.Entities;

namespace ZenjectPrototype.Entities.Modifiers
{
    public abstract class Modifier
    {
        private bool applied = false;

        public bool IsApplied
        {
            get { return applied; }
        }

        public void Apply()
        {
            if(!applied)
            {
                OnApply();
                applied = true;
            }
        }

        public void Detach()
        {
            if(applied)
            {
                OnDetach();
                applied = false;
            }
        }

        protected abstract void OnApply();
        protected abstract void OnDetach();
    }
}
