using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Assets.Inventory;

public class HandInRecipe : MonoBehaviour
{
    public GameObject RecipeHandIn;
    public GameObject RecipeHandInQuestion;
    public GameObject RecipeHandInRating;
    public GameObject LoadingImage;

    public TMP_Text IngredientScoreText;
    public TMP_Text TimerText;
    public TMP_Text GameTimer;

    public RecipeBookController RecipeController;
    public InventorySystem InventorySys;
    private List<GameObject> _ingredientList = new List<GameObject>();

    private float _ingredientPointCount;
    private float _ingredientPointFactor = 100;

    public void YesButton()
    {
        _ingredientList = RecipeController.CurrentIngredientsList;

        for (int i = 0; i < _ingredientList.Count; i++)
        {
            for (int j = 0; j < InventorySys.Inventory.Count; j++)
            {
                if (InventorySys.Inventory[j].name == (_ingredientList[i].name + "(Clone)")) _ingredientPointCount += _ingredientPointFactor;
            }
        }

        IngredientScoreText.text = _ingredientPointCount.ToString();
        TimerText.text = GameTimer.text;

        RecipeHandInQuestion.SetActive(false);
        RecipeHandInRating.SetActive(true);
    }
    public void NoButton()
    {
        
        StopInteraction();
    }

    public void PlayAgainButton()
    {
        Time.timeScale = 1.0f;
        LoadingImage.SetActive(true);
        SceneManager.LoadScene("MainMenu");
    }
    public void StartInteraction()
    {
        Time.timeScale = 0f;
        RecipeHandIn.SetActive(true);
    }
    public void StopInteraction()
    {
        Time.timeScale = 1.0f;
        RecipeHandIn.SetActive(false);
    }

    
}
