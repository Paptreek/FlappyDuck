using UnityEngine;

public class DestroyPillar : MonoBehaviour
{
    void Update()
    {
        if (transform.position.x < -12)
        {
            Destroy(gameObject);
        }
    }
}
