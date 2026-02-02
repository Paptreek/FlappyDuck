using UnityEngine;

// 1. space between pillars should change with each spawn

public class MovePillar : MonoBehaviour
{
    public float moveSpeed = 5.0f;

    private void Start()
    {
        moveSpeed = 5.0f;
    }

    void Update()
    {        
        transform.Translate(new Vector2(-moveSpeed * Time.deltaTime, 0));
    }
}
