using Client.Scripts.Player;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private Inventory _inventory;
    [SerializeField] private bool _isGizmos;

    [ShowIf("_isGizmos"), SerializeField, Range(0, 100)]
    private float _gizmosLineRange;
    
    private Gun _chooseWeapon;
    private RaycastHit _ray;

    private void Start() => _chooseWeapon = _inventory.CurrentWeapon;

    private void OnEnable() => _inventory.WeaponChanged += InventoryOnWeaponChanged;

    private void OnDisable() => _inventory.WeaponChanged -= InventoryOnWeaponChanged;

    private void InventoryOnWeaponChanged(Gun weapon) => _chooseWeapon = weapon;

    public async void Shoot(bool isShooting)
    {
    }

    private void OnDrawGizmos()
    {
        if (_isGizmos)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_inventory.CurrentWeapon.transform.localPosition, new Vector3(0,0,_gizmosLineRange) 
                                                                              + _inventory.CurrentWeapon.transform.localPosition);
        }
    }
}
