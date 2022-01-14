using System.Collections.Generic;
using Client.Scripts.UI.TextNotify;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class Test : MonoBehaviour
{
    [SerializeField] private string _message;

    [SerializeField] private List<string> _messages;

    [Button]
    public void Foo()
    {
        TextNotify.Show(_message, 3f);
    }

    [Button]
    public void ShowAllTexts()
    {
        foreach (var m in _messages) TextNotify.Show(m, 3f);
    }
}
