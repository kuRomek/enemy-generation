using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;
    [SerializeField] private Target _target;

    private bool _isWalking;
    private float _dyingSeconds = 5f;

    private void Awake()
    {
        _isWalking = true;
        _animator.SetBool(UnitAnimatorData.Params.IsWalking, true);
    }

    private void Update()
    {
        if (_isWalking)
        {
            transform.forward = _target.transform.position - transform.position;
            transform.Translate(_speed * Time.deltaTime * transform.forward, Space.World);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Wall wall) || collision.collider.TryGetComponent(out Target target))
            StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        WaitForSeconds dyingSeconds = new WaitForSeconds(_dyingSeconds);
        
        _isWalking = false;
        _animator.SetTrigger(UnitAnimatorData.Params.Die);

        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<Collider>().enabled = false;

        yield return dyingSeconds;
        Destroy(gameObject);
    }

    public void SetTarget(Target target)
    {
        _target = target;
    }
}
