using System;
using System.Collections;
using UnityEngine;



namespace Omotenashi
{
    public class Customer : MonoBehaviour
    {
        [SerializeField] private Emotions _goodEmotion;
        [SerializeField] private Emotions _badEmotion;
        
        //Components
        [SerializeField] private Dialogue _charDialogues;
        [SerializeField] private CustomerAnimator _customerAnimator;
        
        
        //Delagates
        public static event Action OnArrivedAtCounter;
        public static event Action<DialogueType, string> OnDialogue;
        public static event Action OnWaitingForReaction;

        public static event Action OnGoodReaction;
        public static event Action OnBadReaction;
        public static event Action OnNeutral;



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

            if (OnGoodReaction == null)
            {
                OnGoodReaction = delegate { };
            }

            if (OnBadReaction == null)
            {
                OnBadReaction = delegate { };
            }

            if (OnNeutral == null)
            {
                OnNeutral = delegate { };
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
            
            gameObject.transform.localScale = _customerAnimator.StartScale;
            _customerAnimator.SetDefaultSpriteState(true);
            _customerAnimator.SetBadSpriteState(false);
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
            OnDialogue?.Invoke(DialogueType.Intro, _charDialogues.GetIntro());
        }
        
        public void CheckReaction(Emotions emotion)
        {
            if (emotion == _goodEmotion)
            {
                OnDialogue?.Invoke(DialogueType.Reaction, _charDialogues.GetGood());
                OnGoodReaction?.Invoke();
            }
            else if (emotion == _badEmotion)
            {
                _customerAnimator.SetDefaultSpriteState(false);
                _customerAnimator.SetBadSpriteState(true);
                OnDialogue?.Invoke(DialogueType.Reaction, _charDialogues.GetBad());
                OnBadReaction?.Invoke();
            }
            else
            {
                OnDialogue?.Invoke(DialogueType.Reaction, _charDialogues.GetNoReact());
                OnNeutral?.Invoke();
            }
        }

        //Animations
        public void WalksToCounter()
        {
            //Walks to Counter
            StartCoroutine(WalkToCounterAnim());
        }

        public IEnumerator WalkToCounterAnim()
        {
            float currentTime = 0;
            
            while (currentTime <= _customerAnimator.LerpTime)
            {
                gameObject.transform.localScale = Vector3.Lerp(_customerAnimator.StartScale, _customerAnimator.EndScale,
                    _customerAnimator.PercentageComplete(currentTime));
                currentTime += Time.deltaTime;
                yield return null;
            }
            
            //On Arrival
            PlayIntroDialogue();
            yield return null;
        }

        public void WalksAwayFromCounter()
        {
            StartCoroutine(WalksAwayFromCounterAnim());
        }

        public IEnumerator WalksAwayFromCounterAnim()
        {
            float currentTime = 0;
            
            while (currentTime <= _customerAnimator.LerpTime)
            {
                gameObject.transform.localScale = Vector3.Lerp(_customerAnimator.EndScale, _customerAnimator.StartScale,
                    _customerAnimator.PercentageComplete(currentTime));
                currentTime += Time.deltaTime;
                yield return null;
            }
            
            gameObject.SetActive(false);
            yield return null;
        }
    }
}