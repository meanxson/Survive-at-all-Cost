using UnityEditor;
using UnityEngine;

namespace Client.Scripts.Weapon.Editor
{
    public class WeaponEditor : EditorWindow
    {
        [MenuItem("Weapon/Open Weapon Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<WeaponEditor>();
            window.titleContent = new GUIContent("Weapon Editor");
            window.Show();
        }
    }
}