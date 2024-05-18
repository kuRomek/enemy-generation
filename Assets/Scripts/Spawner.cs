using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Unit _unit;
    [SerializeField] private float _secondsToSpawn;
    [SerializeField] private Target _target;

    private Collider _collider;

    private void Awake()
    {
        _collider = GetComponent<BoxCollider>();

        StartCoroutine(Run());
    }

    private IEnumerator Run()
    {
        WaitForSeconds secondsToSpawn = new WaitForSeconds(_secondsToSpawn);

        bool isRunning = true;

        while (isRunning)
        {
            yield return secondsToSpawn;
            Spawn();
        }
    }

    private void Spawn()
    {
        float randomXValue = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        float randomZValue = Random.Range(_collider.bounds.min.z, _collider.bounds.max.z);

        Unit unitToSpawn = Instantiate(_unit, new Vector3(randomXValue, transform.position.y, randomZValue), Quaternion.identity);
        
        unitToSpawn.SetTarget(_target);
    }
}
