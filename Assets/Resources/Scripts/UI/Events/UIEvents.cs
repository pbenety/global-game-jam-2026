using System;
using UnityEngine;

namespace UIPrototype
{
    public static class UIEvents
    {
        public static Action MaskContainerShown;

        public static Action MaskContainerHidden;

        public static Action<Omotenashi.Emotions> MaskClicked;

        public static Action<string> DateIconChanged;

        public static Action<int> MentalHealthChanged;

        public static Action<int> MoneyChanged;
    }
}