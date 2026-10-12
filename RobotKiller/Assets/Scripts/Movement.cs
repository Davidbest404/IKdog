using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    Rigidbody _rb;
    void Start() => _rb = GetComponent<Rigidbody>();
    void FixedUpdate() => _rb.linearVelocity = new Vector3(0, _rb.linearVelocity.y, speed);
}