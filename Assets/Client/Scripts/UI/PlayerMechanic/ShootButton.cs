using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButton : MonoBehaviour, IUpdateSelectedHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerShooter _playerShooter;
    private bool _isPressed;

    //TODO: Shoot Button
    public void OnUpdateSelected(BaseEventData eventData)
    {
        if (_isPressed)
        {
            _playerShooter.Shoot(_isPressed);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPressed = false;
    }
}
