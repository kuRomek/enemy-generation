using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _checkpointsObject;
    [SerializeField] private float _speed;

    private Checkpoint[] _checkpoints;
    private int _currentCheckpointIndex;

    private void Awake()
    {
        _checkpoints = _checkpointsObject.GetComponentsInChildren<Checkpoint>();
        _currentCheckpointIndex = 0;

        transform.forward = _checkpoints[_currentCheckpointIndex].transform.position - transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _checkpoints[_currentCheckpointIndex].transform.position)
            _currentCheckpointIndex = ++_currentCheckpointIndex % _checkpoints.Length;

        transform.position = Vector3.MoveTowards(transform.position, _checkpoints[_currentCheckpointIndex].transform.position, _speed * Time.deltaTime);
    }
}
