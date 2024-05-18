using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _speed;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = -Input.GetAxis("Mouse Y");

        transform.eulerAngles += Vector3.up * horizontalInput;
        transform.localEulerAngles += Vector3.right * verticalInput;
    }

    private void Move()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float sideInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Jump");

        transform.Translate(_speed * Time.deltaTime * forwardInput * transform.forward, Space.World);
        transform.Translate(_speed * Time.deltaTime * Vector3.right * sideInput);
        transform.Translate(_speed * Time.deltaTime * Vector3.up * verticalInput, Space.World);
    }
}
