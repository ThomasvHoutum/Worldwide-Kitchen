using Assets.Inventory;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Food
{
    public class IngredientList : MonoBehaviour
    {
        [SerializeField] private List<BaseIngredient> _allIngredients;
        [SerializeField] private InventorySystem _playerInventory;
        [SerializeField] private int _rating = 0; //Placeholder until we have a better rating method.

        private BaseIngredient _foodToCook;

        private void Awake()
        {
           InitializeList();
        }

        private void InitializeList()
        {
            int selectFood = Random.Range(0, _allIngredients.Count);
            print(selectFood);
            _foodToCook = _allIngredients[selectFood];
            print(_foodToCook);
        }

        public List<BaseIngredient> GetIngredients() { return _allIngredients; }
    } 
}
