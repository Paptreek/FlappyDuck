using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;

    public GameObject quackSound;
    public float jumpForce;
    public int points;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.AddForce(new Vector2(0, jumpForce - jumpForce / 2.5f));
    }

    void OnJump()
    {
        _rb.AddForce(new Vector2(0, jumpForce));
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
