using System;
using System.Collections.Generic;
using UnityEngine;



namespace Omotenashi
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private Dialogue _charDialogues;
        [SerializeField] private Emotions _goodEmotion;
        [SerializeField] private Emotions _badEmotion;
        
        
        //Delagates
        public static event Action OnArrivedAtCounter;
        public static event Action<DialogueType, string> OnDialogue;
        public static event Action OnWaitingForReaction;



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

            if (OnDialogue == null)
            {
                OnDialogue = delegate { };
            }

            if (_charDialogues == null)
            {
                _charDialogues = gameObject.GetComponent<Dialogue>();
            }
        }

        void OnEnable()
        {
            Emotion.OnEmotionSelected += CheckReaction;
            UIManager.OnClosingDialogueClosed += WalksAwayFromCounter;
            OnDialogue += Dialogue;
            
            
            WalksToCounter();
        }

        void OnDisable()
        {
            Emotion.OnEmotionSelected -= CheckReaction;
            UIManager.OnClosingDialogueClosed -= WalksAwayFromCounter;
        }
        
        //Dialogue System
        public void PlayIntroDialogue()
        {
            Debug.Log("Showing dialogue box");
            OnDialogue?.Invoke(DialogueType.Intro, _charDialogues.GetIntro());
        }
        
        public void CheckReaction(Emotions emotion)
        {
            if (emotion == _goodEmotion)
            {
                OnDialogue?.Invoke(DialogueType.Reaction, _charDialogues.GetGood());
            }
            else if (emotion == _badEmotion)
            {
                OnDialogue?.Invoke(DialogueType.Reaction, _charDialogues.GetBad());
            }
            else
            {
                OnDialogue?.Invoke(DialogueType.Reaction, _charDialogues.GetNoReact());
            }
        }

        void Dialogue(DialogueType dialogueType, string dialogue)
        {
            Debug.Log(dialogueType + " " + dialogue);
        }


        //Animations
        public void WalksToCounter()
        {
            //Walks to Counter
            WalkToCounterAnim();
            
            //On Arrival
            PlayIntroDialogue();
        }

        public void WalkToCounterAnim()
        {
            Debug.Log("Walking to the counter");
            
        }

        public void WalksAwayFromCounter()
        {
            Debug.Log("Walks away from the counter");
        }
    }
}