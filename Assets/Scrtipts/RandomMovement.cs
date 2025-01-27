using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [Range (3, 20)] // Slider in Unity
    public float speed = 7f; // Speed of the movement

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector2 movement = Random.insideUnitCircle.normalized;
        // Other example
        // var x = Random.Range(-1f, 1f);
        // var y = Random.Range(-1f, 1f);
        // var movement = new Vector2(x, y).normalized;
        _rigidbody2D.linearVelocity = movement * speed;
    }
}
