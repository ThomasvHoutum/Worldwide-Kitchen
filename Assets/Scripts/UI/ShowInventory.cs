using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Assets.Food;
using Assets.Inventory;

namespace Assets.UI
{
    public class ShowInventory : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _itemImages;
        [SerializeField] private InventorySystem _inventorySystem;
        [SerializeField] private List<Image> _uiImages;
        private void Awake()
        {
            _itemImages = new List<Sprite>();
            List<BaseIngredient> ingredientList = _inventorySystem.GetInventory();
        }

        public void AddToUi(Sprite imageToAdd)
        {
            _itemImages.Add(imageToAdd);
            print(_itemImages.Count);
            for (int i = 0; i < _itemImages.Count; i++)
            {
                print(i);
                if (i >= _uiImages.Count) return;
                _uiImages[i].gameObject.SetActive(true);
                _uiImages[i].sprite = _itemImages[i];
            }
        }
    }
}
