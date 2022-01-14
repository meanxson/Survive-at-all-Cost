using UnityEngine;
using Random = UnityEngine.Random;

public class LootBoxSpawner : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _spawnRange;

    [SerializeField] private LootBox _lootBox;
    [SerializeField] private int _startCountOfBox;

    private void Start()
    {
        for (var i = 0; i < _startCountOfBox; i++)
        {
            Instantiate(_lootBox, new Vector3(
                    Random.Range(0, _spawnRange), _lootBox.transform.position.y, 
                    Random.Range(0, _spawnRange)),
                Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _spawnRange);
    }
}