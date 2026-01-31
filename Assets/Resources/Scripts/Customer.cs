using System;
using System.Collections.Generic;
using UnityEngine;



namespace Omotenashi
{
    public class Customer : MonoBehaviour
    {

        //public List<Dialogue> CharDialogues;
        [SerializeField] private Dialogue _charDialogues;
        public int _dialogueIndex = 0;


        public GameObject button;
        
        //Delagates
        public static event Action OnArrivedAtCounter;
        public static event Action OnWaitingForReaction;

        //Start Dialogue



        void Awake()
        {
            if (OnArrivedAtCounter == null)
            {
                OnArrivedAtCounter = delegate { };
            }

            if (OnWaitingForReaction == null)
            {
                OnWaitingForReaction = delegate { };
            }

            if (_charDialogues == null)
            {
                _charDialogues = gameObject.GetComponent<Dialogue>();
            }
        }

        void Start()
        {
            Emotion.OnEmotionSelected += Reaction;
            OnWaitingForReaction += SetUpReaction;
            
            
            WalksToCounter();
        }

        void OnDestroy()
        {
            Emotion.OnEmotionSelected -= Reaction;
            OnWaitingForReaction -= SetUpReaction;
        }
        
        //Dialogue System
        public void PlayIntroDialogue()
        {
            Debug.Log("Playing intro dialogue");
            
            OnWaitingForReaction?.Invoke();
        }

        public void SetUpReaction()
        {
            button.SetActive(true);
        }

        public void HideButton()
        {
            button.SetActive(false);
        }

        public void Reaction(Emotions emotion)
        {
            HideButton();
            switch (emotion)
            {
                case Emotions.Neutral:
                {
                    Debug.Log(emotion);
                    break;
                }
                case Emotions.Happy:
                {
                    Debug.Log(emotion);
                    break;
                }
                case Emotions.Sad:
                {
                    Debug.Log(emotion);
                    break;
                }
                case Emotions.Angry:
                {
                    Debug.Log(emotion);
                    break;
                }
            }
        }


        //Animations
        public void WalksToCounter()
        {
            //Walks to Counter
            WalkToCounterAnim();
            //On Finish need to broadcast Complete
            PlayIntroDialogue();
            //OnArrivedAtCounter?.Invoke();
        }

        public void WalkToCounterAnim()
        {
            Debug.Log("Walking to the counter");
            //throw new System.NotImplementedException();
        }

        public void WalksAwayFromCounter()
        {

        }
    }
}