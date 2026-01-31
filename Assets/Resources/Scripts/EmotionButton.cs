using UnityEngine;


namespace Omotenashi
{
    public class EmotionButton : MonoBehaviour
    {
        [SerializeField] private Emotions _buttonStateValue;
        public Emotions ButtonStateValue { get { return _buttonStateValue; } }
        
        //Components
        Emotion _emotion;

        void Awake()
        {
            _emotion = new Emotion(_buttonStateValue);
        }

        public void OnClick()
        {
            _emotion.EmotionSelected();
        }
    }
}