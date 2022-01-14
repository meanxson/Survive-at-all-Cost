using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Client.Scripts.UI.TextNotify
{
    public class NotifyTextPool : MonoBehaviour
    {
        [SerializeField] private NotifyTextSegment _prefabText;
        [SerializeField] private Transform _parent;

        [field: SerializeField] public int CountOfText { get; private set; }

        [field: SerializeField] public List<NotifyTextSegment> Texts { get; private set; }

        private void Awake()
        {
            Sign();
        }

        private void Start()
        {
            for (var i = 0; i < CountOfText; i++)
            {
                Texts.Add(Instantiate(_prefabText,_parent.position, Quaternion.identity ,_parent));
                Texts[i].gameObject.SetActive(false);
            }
        }

        private void Sign()
        {
            _prefabText.OnShow.AddListener((() =>
            {
                _prefabText.TMPText.text = "";
            }));
        }
    }
}