using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private Unit[] _units;
    [SerializeField] private float _secondsToSpawn;

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

        Unit unitToSpawn = Instantiate(_units[Random.Range(0, _units.Length)], new Vector3(randomXValue, transform.position.y, randomZValue), Quaternion.identity);

        float randomAngle = Random.Range(0, 2f * Mathf.PI);
        unitToSpawn.transform.forward = new Vector3(Mathf.Cos(randomAngle), transform.position.y, Mathf.Sin(randomAngle));
    }
}
