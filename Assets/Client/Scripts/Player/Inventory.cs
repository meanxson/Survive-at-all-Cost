using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Client.Scripts.Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private Transform _weaponPosition;
        
        [field: SerializeField] public Gun StartWeapon { get; private set; }
        public List<Gun> Weapons { get; private set; }
        public Gun CurrentWeapon { get; private set; }

        public event UnityAction<Gun> WeaponChanged;

        private int _indexWeapon;

        private void Start()
        {
            CurrentWeapon = StartWeapon;
            _indexWeapon = 0;

            CurrentWeapon = Instantiate(StartWeapon, _weaponPosition.position, Quaternion.identity, _weaponPosition);
        }

        public void PickUp(Gun weapon)
        {
            Weapons.Add(weapon);
        }

        public void ChangeWeaponUp()
        {
            if (_indexWeapon != Weapons.Count)
            {
                CurrentWeapon = Weapons[++_indexWeapon];
                WeaponChanged?.Invoke(CurrentWeapon);
            }
        }

        public void ChangeWeaponDown()
        {
            if (_indexWeapon != 0)
            {
                CurrentWeapon = Weapons[--_indexWeapon];
                WeaponChanged?.Invoke(CurrentWeapon);
            }
        }
    }
}