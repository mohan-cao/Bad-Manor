using System;
using UnityEngine;

namespace Assets.Scripts
{
    /// <summary>
    /// CharacterManager manages all characters in the game. It currently has no respoonsibility for the prototype
    /// but in the future it will manage movement, interaction and dialogue of them. It currently doesn't depend on any
    /// other class at the moment but it will liekly depend on Character later.</summary>
    [Serializable()]
    public class CharacterManager : MonoBehaviour
    {
        /// <summary>
        /// The time for which characters move in the game per phsyics frame.</summary>
        public float moveTime = 0.1f;
    }
}