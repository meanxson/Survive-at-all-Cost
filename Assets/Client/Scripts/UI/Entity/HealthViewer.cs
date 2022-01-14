using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
  [SerializeField] private HealthContainer _healthContainer;
  [SerializeField] private Slider _slider;
  [SerializeField] private float _duration;

  [SerializeField] private Image[] _fadeEffectImages;

  private void Start()
  {
    foreach (var effectImage in _fadeEffectImages)
      effectImage.DOFade(0, 0);
  }

  private void OnEnable() => _healthContainer.OnHealthChanged += OnHealthChanged;

  private void OnDisable() => _healthContainer.OnHealthChanged -= OnHealthChanged;

  private void OnHealthChanged(int value) => _slider.DOValue(value, _duration);

  public void Show()
  {
    foreach (var effectImage in _fadeEffectImages) 
      effectImage.DOFade(1, _duration / 2);
  }

  public void Hide()
  {
    foreach (var effectImage in _fadeEffectImages)
      effectImage.DOFade(0, _duration / 2);
  }
}
