using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
  [SerializeField] private HealthContainer _healthContainer;
  [SerializeField] private Slider _slider;
  [SerializeField] private float _duration;
  
  private void OnEnable()
  {
    _healthContainer.OnHealthChanged += OnHealthChanged;
  }

  private void OnDisable()
  {
    _healthContainer.OnHealthChanged -= OnHealthChanged;
  }

  private void OnHealthChanged(int value)
  {
    _slider.DOValue(value, _duration);
  }
}
