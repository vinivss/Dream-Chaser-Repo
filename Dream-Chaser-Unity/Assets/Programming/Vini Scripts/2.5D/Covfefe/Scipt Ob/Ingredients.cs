using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Coffee
{
    public class Ingredients : ScriptableObject
    {
        [Header("Attributes")]
        public string IngredientName;
        [TextArea] public string description;
    }
}
