using UnityEngine;

namespace UIPrototype
{
    public class TestUIPrototype : MonoBehaviour
    {
        [SerializeField] private int _mentalHealth = 5;
        [SerializeField] private int _money = 500;
        [SerializeField] private DateIcon _DateIcon;

        private bool _showMasks = true;

        private void OnEnable()
        {
            UIEvents.MaskClicked += OnMaskClicked;
        }

        private void OnDisable()
        {
            UIEvents.MaskClicked -= OnMaskClicked;
        }

        private void OnMaskClicked(Omotenashi.Emotions emotion)
        {
            Debug.Log(emotion.ToString());

            UIEvents.MoneyChanged?.Invoke(_money);

            UIEvents.MentalHealthChanged?.Invoke(_mentalHealth);

            string dateIconPath;

            switch (_DateIcon)
            {
                case DateIcon.Monday:
                    dateIconPath = "Art/UI/Monday";
                    break;
                case DateIcon.Tuesday:
                    dateIconPath = "Art/UI/Tuesday";
                    break;
                case DateIcon.Wednesday:
                    dateIconPath = "Art/UI/Wednesday";
                    break;
                case DateIcon.Thursday:
                    dateIconPath = "Art/UI/Thursday";
                    break;
                case DateIcon.Friday:
                    dateIconPath = "Art/UI/Friday";
                    break;
                default:
                    dateIconPath = "Art/UI/Monday";
                    break;
            }

            UIEvents.DateIconChanged?.Invoke(dateIconPath);
        }

        public void HideMaskButtons()
        {
            if (_showMasks)
            {
                UIEvents.MaskContainerHidden?.Invoke();
            }
            else
            {
                UIEvents.MaskContainerShown?.Invoke();
            }
            _showMasks = !_showMasks;
        }
    }


    public enum DateIcon
    {
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
    }
}
