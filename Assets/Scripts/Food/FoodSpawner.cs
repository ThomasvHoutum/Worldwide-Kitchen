using System.Collections.Generic;
using UnityEngine;

namespace Assets.Food
{
    public class FoodSpawner : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _asiaFoodList = new List<GameObject>();
        [SerializeField] private List<GameObject> _asiaSpawnList = new List<GameObject>();

        [SerializeField] private List<GameObject> _europeFoodList = new List<GameObject>();
        [SerializeField] private List<GameObject> _europeSpawnList = new List<GameObject>();

        [SerializeField] private List<GameObject> _oceaniaFoodList = new List<GameObject>();
        [SerializeField] private List<GameObject> _oceaniaSpawnList = new List<GameObject>();

        [SerializeField] private List<GameObject> _africaFoodList = new List<GameObject>();
        [SerializeField] private List<GameObject> _africaSpawnList = new List<GameObject>();

        private void Awake()
        {
            SpawnFood(_asiaFoodList, _asiaSpawnList);
            SpawnFood(_europeFoodList, _europeSpawnList);
            SpawnFood(_africaFoodList, _africaSpawnList);
            SpawnFood(_oceaniaFoodList, _oceaniaSpawnList);
        }

        /// <summary>
        /// Spawns the food gameobjects and takes a random index.
        /// </summary>
        private void SpawnFood(List<GameObject> AreaFoodList, List<GameObject> AreaSpawnList)
        {
            List<int> RandomList = new List<int>();
            for (int i = 0; i < AreaFoodList.Count; i++)
            {
                GameObject FoodItem = Instantiate<GameObject>(AreaFoodList[i].gameObject);
            }
            for (int itr = 0; itr < AreaSpawnList.Count; itr++)
            {
                if (itr == AreaFoodList.Count)
                {
                    return;
                }
                int random = Random.Range(0, AreaSpawnList.Count);
                if (!RandomList.Contains(random))
                {
                    RandomList.Add(random);
                    Transform spawnlocation = AreaSpawnList[random].gameObject.GetComponent<Transform>();
                    AreaFoodList[itr].GetComponent<Transform>().position = spawnlocation.position;
                }
                else
                {
                    itr--;
                }
            }
        }
    } 
}
