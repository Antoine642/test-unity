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
        if (GameManager.Instance.IsGameStarted)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            _movement = new Vector2(horizontal, vertical).normalized;

            _animator.SetFloat("Horizontal", horizontal);
            _animator.SetFloat("Vertical", vertical);
            _animator.SetFloat("Velocity", _movement.sqrMagnitude);
        }
        else
        {
            _movement = Vector2.zero;
        }
    }

    private void FixedUpdate()
    {
        if (GameManager.Instance.IsGameStarted)
        {
            _rigidbody2D.linearVelocity = _movement * speed;
        }
        else
        {
            _rigidbody2D.linearVelocity = Vector2.zero;
        }
    }

    public void ResetPosition(Vector3 startPosition)
    {
        transform.position = startPosition;
    }

    public void Freeze()
    {
        _animator.enabled = false;
    }

    public void Unfreeze()
    {
        _animator.enabled = true;
    }
}
