using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Client.Scripts.UI.TextNotify
{
    public class NotifyTextSegment : MonoBehaviour
    {
        [field: SerializeField] public TMP_Text TMPText { get; private set; }
        
        public UnityEvent OnShow { get; private set; }
        public UnityEvent OnHide { get; private set; }

        private void OnEnable() => OnShow?.Invoke();
        private void OnDisable() => OnHide?.Invoke();
    }
}