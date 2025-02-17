using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _movement;
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    [Range(3, 20)] // Slider in Unity
    public float speed = 7f; // To declare float : finish by 'f'

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        _movement = new Vector2(horizontal, vertical).normalized;

        _animator.SetFloat("Horizontal", horizontal);
        _animator.SetFloat("Vertical", vertical);
        _animator.SetFloat("Velocity", _movement.sqrMagnitude);

    }

    private void FixedUpdate()
    {
        _rigidbody2D.linearVelocity = _movement * speed;
    }
}
