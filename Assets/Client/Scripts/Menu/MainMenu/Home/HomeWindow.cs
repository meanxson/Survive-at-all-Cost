using Michsky.UI.ModernUIPack;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class HomeWindow : BaseWindow
{
    [SerializeField] private Button[] _buttons;
    [SerializeField] private ModalWindowManager _modal;

    private void Awake()
    {
        SignButtons(
            Manager.OpenWindow<GameWindow>,
            Manager.OpenWindow<SettingWindow>,
            Exit
        );
    }

    private void SignButtons(params UnityAction[] actions)
    {
        for (var i = 0; i < _buttons.Length; i++)
            _buttons[i].onClick.AddListener(actions[i]);
    }

    private void Exit()
    {
        _modal.OpenWindow();
        _modal.onConfirm.AddListener((Application.Quit));
    }

    [Button]
    private void InitButtons() => _buttons = GetComponentsInChildren<Button>(true);
}