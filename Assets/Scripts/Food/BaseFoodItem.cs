using System.Collections.Generic;
using UnityEngine;

namespace Assets.Food
{
    public class BaseFoodItem : BaseIngredient
    {
       [SerializeField] protected List<BaseIngredient> ingredients;

        private void Awake()
        {
            ingredients = new List<BaseIngredient>();
        }
    }
}