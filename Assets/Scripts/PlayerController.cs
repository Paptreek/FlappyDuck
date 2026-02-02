using UnityEngine;

// 1. Gain points whenever player passes a pillar. (Prob make a GameManager script for this)

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public float jumpForce;
    public int points;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnJump()
    {
        _rb.AddForce(new Vector2(0, jumpForce));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pillar") || collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Points"))
        {
            points += 1;
        }
    }
}
