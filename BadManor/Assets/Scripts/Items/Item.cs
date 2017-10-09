using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    public abstract class Item : MonoBehaviour
    {
		public string name;

        public Item()
        {
            name = null;
        }
        
        public Item(String _name)
        {
            name = _name;
        }
    }
}
