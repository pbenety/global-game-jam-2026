using UnityEngine;

namespace Omotenashi
{
    public class CustomerAnimator : MonoBehaviour
    {
        [SerializeField] private float _startScale;
        public Vector3 StartScale { get { return new Vector3(_startScale, _startScale, _startScale); } }

        [SerializeField] private float _endScale;
        public Vector3 EndScale { get { return new Vector3(_endScale, _endScale, _endScale); }
        }

        [SerializeField] private float _timeToLerp;
        public float LerpTime { get { return _timeToLerp; } }
        
        
        [SerializeField] private GameObject _defaultSprite;
        [SerializeField] private GameObject _badSprite;
        

        public float PercentageComplete(float currentTime)
        {
            return currentTime / _timeToLerp;
        }


        public void SetDefaultSpriteState(bool state)
        {
            _defaultSprite.SetActive(state);
        }

        public void SetBadSpriteState(bool state)
        {
            _badSprite.SetActive(state);
        }
    }
}
