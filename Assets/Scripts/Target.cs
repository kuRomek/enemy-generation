using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _checkpointsObject;
    [SerializeField] private float _speed;

    private Checkpoint[] _checkpoints;
    private Checkpoint _currentCheckpoint;
    private int _currentCheckpointIndex;

    private void Awake()
    {
        _checkpoints = _checkpointsObject.GetComponentsInChildren<Checkpoint>();
        _currentCheckpointIndex = 0;
        _currentCheckpoint = _checkpoints[_currentCheckpointIndex];

        transform.forward = _currentCheckpoint.transform.position - transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position == _currentCheckpoint.transform.position)
        {
            _currentCheckpointIndex++;
            _currentCheckpointIndex %= _checkpoints.Length;
            _currentCheckpoint = _checkpoints[_currentCheckpointIndex];
        }

        transform.position = Vector3.MoveTowards(transform.position, _currentCheckpoint.transform.position, _speed * Time.deltaTime);
    }
}
