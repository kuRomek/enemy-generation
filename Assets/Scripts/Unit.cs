using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Unit : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _speed;

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
            transform.Translate(_speed * Time.deltaTime * Vector3.forward);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Wall wall))
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
}
