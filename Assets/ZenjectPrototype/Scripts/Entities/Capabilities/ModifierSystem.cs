using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using ZenjectPrototype.Entities.Modifiers;

namespace ZenjectPrototype.Entities.Capabilities
{
    public class ModifierSystem : IModifiable
    {
        private List<Modifier> modifiers = new List<Modifier>();

        public IEnumerable Modifiers
        {
            get { return modifiers; }
        }

        public void Register(Modifier modifier)
        {
            if (!modifiers.Contains(modifier))
            {
                modifiers.Add(modifier);
                modifier.Apply();
            }
        }
    }
}
