using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;

public abstract class BaseWindowManager : MonoBehaviour
{
    [field: SerializeField] public BaseWindow[] Windows { get; private set; }

    public void OpenWindow<T>() where T : BaseWindow
    {
        var window = Windows.FirstOrDefault((w => w is T));
        if (!ReferenceEquals(window, null)) window.Open();
    }

    public void CloseWindow<T>() where T : BaseWindow
    {
        var window = Windows.FirstOrDefault((w => w is T));
        if (!ReferenceEquals(window, null)) window.Close();
    }

    public void CloseAllWindows()
    {
        if (!ReferenceEquals(Windows, null))
            foreach (var w in Windows)
                w.Close();
    }

    [Button]
    private void InitWindows() => Windows = GetComponentsInChildren<BaseWindow>(true);
}