using UnityEngine;
using UnityEngine.UIElements;

namespace UIPrototype
{
    [RequireComponent(typeof(UIDocument))]
    public class UIManager : MonoBehaviour
    {

        private UIDocument _uiDocument;

        private VisualElement _MasksContainer;
        private VisualElement _HappyMaskButton;
        private VisualElement _AngerMaskButton;
        private VisualElement _NeutralMaskButton;
        private VisualElement _SadMaskButton;
        private VisualElement _DateIcon;
        private Slider _MentalHealthSlider;
        private Label _MoneyValue;

        private void OnEnable()
        {
            _uiDocument = GetComponent<UIDocument>();

            SetVisualElements();

            SubscribeToEvents();

            RegisterButtonCallbacks();
        }

        private void SubscribeToEvents()
        {
            UIEvents.MaskContainerShown += OnMaskContainerShown;
            UIEvents.MaskContainerHidden += OnMaskContainerHidden;
            UIEvents.DateIconChanged += OnDateIconChanged;
            UIEvents.MentalHealthChanged += OnMentalHealthChanged;
            UIEvents.MoneyChanged += OnMoneyChanged;
        }

        private void RegisterButtonCallbacks()
        {
            _HappyMaskButton.RegisterCallback<ClickEvent>(ClickHappyMaskButton);
            _AngerMaskButton.RegisterCallback<ClickEvent>(ClickAngerMaskButton);
            _NeutralMaskButton.RegisterCallback<ClickEvent>(ClicNeutralMaskButton);
            _SadMaskButton.RegisterCallback<ClickEvent>(ClickSadMaskButton);
        }

        private void OnDisable()
        {
            UnsubscribeFromEvents();

            UnregisterButtonCallbacks();
        }

        private void UnsubscribeFromEvents()
        {
            UIEvents.MaskContainerShown -= OnMaskContainerShown;
            UIEvents.MaskContainerHidden -= OnMaskContainerHidden;
            UIEvents.DateIconChanged -= OnDateIconChanged;
            UIEvents.MentalHealthChanged -= OnMentalHealthChanged;
            UIEvents.MoneyChanged -= OnMoneyChanged;
        }

        private void UnregisterButtonCallbacks()
        {
            _HappyMaskButton.UnregisterCallback<ClickEvent>(ClickHappyMaskButton);
            _AngerMaskButton.UnregisterCallback<ClickEvent>(ClickAngerMaskButton);
            _NeutralMaskButton.UnregisterCallback<ClickEvent>(ClicNeutralMaskButton);
            _SadMaskButton.UnregisterCallback<ClickEvent>(ClickSadMaskButton);
        }

        private void SetVisualElements()
        {
            VisualElement root = _uiDocument.rootVisualElement;

            _MasksContainer = root.Q<VisualElement>("MaskBarContainer");
            _HappyMaskButton = root.Q<VisualElement>("HappyMaskButton");
            _AngerMaskButton = root.Q<VisualElement>("AngerMaskButton");
            _NeutralMaskButton = root.Q<VisualElement>("NeutralMaskButton");
            _SadMaskButton = root.Q<VisualElement>("SadMaskButton");
            _DateIcon = root.Q<VisualElement>("DateIcon");
            _MentalHealthSlider = root.Q<Slider>("MentalHealthSlider");
            _MentalHealthSlider.SetEnabled(false);
            _MentalHealthSlider.style.opacity = 1.0f;
            _MoneyValue = root.Q<Label>("MoneyValue");
        }

        private void OnMaskContainerShown()
        {
            _MasksContainer.style.display = DisplayStyle.Flex;
        }

        private void OnMaskContainerHidden()
        {
            _MasksContainer.style.display = DisplayStyle.None;
        }

        private void ClickHappyMaskButton(ClickEvent clickEvent)
        {
            UIEvents.MaskClicked?.Invoke(Omotenashi.Emotions.Happy);
        }

        private void ClickAngerMaskButton(ClickEvent clickEvent)
        {
            UIEvents.MaskClicked?.Invoke(Omotenashi.Emotions.Angry);
        }

        private void ClicNeutralMaskButton(ClickEvent clickEvent)
        {
            UIEvents.MaskClicked?.Invoke(Omotenashi.Emotions.Neutral);
        }

        private void ClickSadMaskButton(ClickEvent clickEvent)
        {
            UIEvents.MaskClicked?.Invoke(Omotenashi.Emotions.Sad);
        }

        private void OnDateIconChanged(string spritePath)
        {
            _DateIcon.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(spritePath));
        }

        private void OnMentalHealthChanged(int value)
        {
            _MentalHealthSlider.value = value;
        }

        private void OnMoneyChanged(int value)
        {
            _MoneyValue.text = value.ToString();
        }
    }
}
