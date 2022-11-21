using System.Collections.Generic;
using UnityEngine;

public class RecipeBookController : MonoBehaviour
{
    [SerializeField] private GameObject _background;
    [SerializeField] private List<GameObject> _blackedOutPages = new List<GameObject>();
    [SerializeField] private List<GameObject> _normalPages = new List<GameObject>();

    private bool _firstLook = true;
    private int _randomPage;
    private GameObject _currentPage;

    [HideInInspector] public List<GameObject> CurrentIngredientsList = new List<GameObject>();

    private void Start()
    {
        _randomPage = Random.Range(0, _normalPages.Count);
        CurrentIngredientsList = _normalPages[_randomPage].GetComponent<RecipeHolder>().IngredientList;
        _currentPage = _normalPages[_randomPage];
    }

    public void StartInteraction()
    {
        Time.timeScale = 0f;
        _background.SetActive(true);
        if (_firstLook)
        {
            _firstLook = false;
            _normalPages[_randomPage].SetActive(true);
            _currentPage = _normalPages[_randomPage];
        }
        else
        {
            _blackedOutPages[_randomPage].SetActive(true);
            _currentPage = _blackedOutPages[_randomPage];
        }
    }

    public void StopInteraction()
    {
        Time.timeScale = 1.0f;
        _background.SetActive(false);
        _currentPage.SetActive(false);
    }
}
