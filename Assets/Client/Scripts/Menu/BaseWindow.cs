using UnityEngine;

public abstract class BaseWindow : MonoBehaviour
{
    protected BaseWindowManager Manager { get; private set; }

    private void OnValidate() => Manager = GetComponentInParent<BaseWindowManager>();

    public void Open()
    {
        Manager.CloseAllWindows();
        gameObject.SetActive(true);
    }

    public void Close() => gameObject.SetActive(false);
}