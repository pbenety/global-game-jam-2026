using System;
using System.Collections;
using UnityEngine;

namespace Omotenashi
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private int round = 1;

        [SerializeField] private int countDown = 2;

        //Delegate
        public static event Action OnGameStart;

        void Awake()
        {
            if (OnGameStart == null)
            {
                OnGameStart = delegate { };
            }
        }

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            StartCoroutine(Countdown());
        }

        private void StartGame()
        {
            OnGameStart?.Invoke();
        }

        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(countDown);

            StartGame();
        }
    }
}