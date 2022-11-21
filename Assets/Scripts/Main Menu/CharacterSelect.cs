using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.UI
{
    public class CharacterSelect : MonoBehaviour
    {
        [SerializeField] private List<Button> _playerOneButtons;
        [SerializeField] private List<Button> _playerTwoButtons;
        [SerializeField] private TMP_Text _selectText;

        public Selection _selection = Selection.none;
        string key = "Selection Player 1";

        public void SelectEurope()
        {
            _selection = Selection.europe;
            StoreSelection(key);
            ToggleInactive(_playerOneButtons, _playerTwoButtons);
        }

        public void SelectOceania()
        {
            _selection = Selection.Oceania;
            StoreSelection(key);
            ToggleInactive(_playerOneButtons, _playerTwoButtons);
        }

        public void SelectAfrica()
        {
            _selection = Selection.Africa;
            StoreSelection(key);
            ToggleInactive(_playerOneButtons, _playerTwoButtons);
        }

        public void SelectAsia()
        {
            _selection = Selection.Asia;
            StoreSelection(key);
            ToggleInactive(_playerOneButtons, _playerTwoButtons);
        }

        private void ToggleInactive(List<Button> ActiveList, List<Button> InactiveList)
        {
            bool toggle = true;
            foreach (Button button in ActiveList)
            {
               button.gameObject.SetActive(false);
            }
            foreach(Button button in InactiveList)
            {
                button.gameObject.SetActive(true);
            }
            if(toggle)
            {
                key = "Selection Player 2";
                _selectText.text = "Player 2 please select your character";
                toggle = false;
            }
            else
            {
                key = "Selection Player 1";
                _selectText.text = "Player 1 please select your character";
                toggle = true;
            }
        }

        public void LoadLevelScene()
        {
            SceneController.Instance.EnableScene();
        }

        private void StoreSelection(string selectionKey)
        {
            PlayerPrefs.SetInt(selectionKey, (int)_selection);
        }

        public enum Selection
        {
            none = 0,
            europe = 1,
            Oceania = 2,
            Africa = 3,
            Asia = 4
        }
    }
}
