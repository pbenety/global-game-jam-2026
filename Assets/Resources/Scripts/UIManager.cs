using System;
using TMPro;
using UnityEngine;


namespace Omotenashi
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject _dialogueBox;
        [SerializeField] private TextMeshProUGUI _dialogueText;
        [SerializeField] private GameObject _emotionsGUI;


        //Variables
        [SerializeField] private DialogueType currentDialogueType;
        
        //Delegates
        public static event Action OnClosingDialogueClosed;

        void Awake()
        {
            if (OnClosingDialogueClosed == null)
            {
                OnClosingDialogueClosed = delegate { };
            }
        }
        
        void Start()
        {
            Customer.OnDialogue += ShowDialogueBox;
            Emotion.OnEmotionSelected += OnHideEmotionBox;
        }

        void OnDestroy()
        {
            Customer.OnDialogue -= ShowDialogueBox;
            Emotion.OnEmotionSelected -= OnHideEmotionBox;
        }

        public void ShowDialogueBox(DialogueType dialogueType, string dialogue)
        {
            
            _dialogueText.text = dialogue;
            currentDialogueType = dialogueType;
            
            _dialogueBox.SetActive(true);
        }

        public void OnContinue()
        {
            //Hide Dialoguebox
            _dialogueBox.SetActive(false);

            if (currentDialogueType == DialogueType.Intro)
            {
                //Show EmotionBox
                _emotionsGUI.SetActive(true);
            }
            else
            {
                OnClosingDialogueClosed?.Invoke();
            }
        }

        public void OnHideEmotionBox(Emotions emotion)
        {
            _emotionsGUI.SetActive(false);
        }
        
    }
}