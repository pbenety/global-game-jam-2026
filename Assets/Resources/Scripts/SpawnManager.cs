using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Omotenashi
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] _customerPrefabs;
        private GameObject[] _customers;

        bool gameActive = true;
        
        void Awake()
        {
            _customers = new GameObject[_customerPrefabs.Length];
            
            for (int i = 0; i < _customerPrefabs.Length; i++)
            {
                _customers[i] = Instantiate(_customerPrefabs[i]);
                _customers[i].SetActive(false);
            }
            
        }

        void Start()
        {
            Customer.OnDespawn += StartSpawning;
            
            StartSpawning();
        }

        private void OnDestroy()
        {
            Customer.OnDespawn -= StartSpawning;
        }

        void StartSpawning()
        {
            if (gameActive)
            {
                int randomIndex = GetRandomIndex();
                _customers[randomIndex].SetActive(true);
            }
        }

        private int GetRandomIndex()
        {
            return Random.Range(0, _customerPrefabs.Length);
        }
    }
}