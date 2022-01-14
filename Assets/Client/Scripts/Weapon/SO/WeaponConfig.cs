using Sirenix.OdinInspector;
using UnityEngine;


[CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/Create Weapon", order = 0)]
public class WeaponConfig : ScriptableObject
{
    [field: SerializeField] public Bullet Bullet;

    [field: SerializeField] public int Damage { get; private set; }
    [field: SerializeField] public int Rate { get; private set; }

    [BoxGroup("Naming")]
    [field: SerializeField]
    public bool AutoNameFill { get; private set; }

    [BoxGroup("Naming")]
    [field: SerializeField]
    public string Name { get; private set; }

    [field: SerializeField] public bool IsInfinityAmmo { get; private set; }

    [HideIf(nameof(IsInfinityAmmo))]
    [field: SerializeField]
    public int Ammo { get; private set; }

    [HideIf(nameof(IsInfinityAmmo))]
    [field: SerializeField]
    public int FireAmmo { get; private set; }

    private void OnValidate()
    {
        if (AutoNameFill) Name = name;
    }

    private void Awake()
    {
        if (IsInfinityAmmo)
        {
            Ammo = int.MaxValue;
            FireAmmo = int.MaxValue;
        }
    }
}