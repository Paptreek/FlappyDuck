using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public GameObject quackSound;
    public float jumpForce;
    public int points;
    public bool canJump = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(0, jumpForce - jumpForce / 2.5f));
    }

    void OnJump()
    {
        if (canJump)
        {
            _rb.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pillar") || collision.gameObject.CompareTag("Wall"))
        {
            quackSound.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Points"))
        {
            GetComponent<AudioSource>().Play();
            points += 1;
        }
    }
}
