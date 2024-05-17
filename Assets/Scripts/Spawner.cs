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

    private Unit Spawn()
    {
        float randomXValue = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        float randomZValue = Random.Range(_collider.bounds.min.z, _collider.bounds.max.z);

        float maxDegrees = 360f;
        Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, maxDegrees), 0f);

        Unit unitToSpawn = _units[Random.Range(0, _units.Length)];

        return Instantiate(unitToSpawn, new Vector3(randomXValue, transform.position.y, randomZValue), randomRotation);
    }
}
