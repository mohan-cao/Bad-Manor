using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Items
{
    /// <summary>
    /// Item represents items in the game, they have names for what they are.</summary>
    [Serializable()]
    public abstract class Item : MonoBehaviour
    {
        /// <summary>
        /// The name of the item.</summary>
		public string name;

        /// <summary>
        /// Creates the item.</summary>
        public Item()
        {
            name = null;
        }
        
        /// <summary>
        /// Creates the item with a name.</summary>
        public Item(String _name)
        {
            name = _name;
        }
    }
}
