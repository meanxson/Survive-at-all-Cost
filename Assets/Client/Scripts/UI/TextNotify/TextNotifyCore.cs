using System.Collections;
using Client.Scripts.UI.TextNotify;
using DG.Tweening;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(NotifyTextPool))]
public class TextNotifyCore : MonoBehaviour
{
    public static TextNotifyCore Instance { get; private set; }

    [SerializeField] private NotifyTextPool _textPool;

    [InfoBox("X - Start Position, Y- End Position")] [SerializeField]
    private Vector2 _animationPositions;

    private Coroutine _coroutine;
    private int _index;
    private float _endPosition;

    private void Awake()
    {
        if (ReferenceEquals(Instance, null)) Instance = this;
        _endPosition = _animationPositions.y;
    }

    public void Show(string text, float duration)
    {
        if (!ReferenceEquals(_coroutine, null))
            StopCoroutine(_coroutine);

        var tmpText = _textPool.Texts[_index++].TMPText;
        tmpText.text = text;

        _coroutine = StartCoroutine(ShowAnimation(tmpText, duration));
        _endPosition += 4f;

        if (_index >= _textPool.Texts.Count)
        {
            _endPosition = _animationPositions.y;
            _index = 0;
        }

    }

    private IEnumerator ShowAnimation(TMP_Text text, float duration)
    {
        text.DOFade(1, duration / 4).OnStart(() => text.gameObject.SetActive(true));
        transform.DOMoveY(_endPosition, duration / 2);
        yield return new WaitForSeconds(duration);
        transform.DOMoveY(_animationPositions.x, duration / 2);
        text.DOFade(0, duration / 4).OnComplete(() =>
        {
            StopCoroutine(_coroutine);
            text.gameObject.SetActive(true);
        });
    }

    [ButtonGroup("Set Position")]
    [Button]
    private void SetStartPosition() => _animationPositions.x = transform.position.y;

    [ButtonGroup("Set Position")]
    [Button]
    private void SetEndPosition() => _animationPositions.y = transform.position.y;
}