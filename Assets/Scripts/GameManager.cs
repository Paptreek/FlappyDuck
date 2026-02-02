using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject obstacle;

    public TMP_Text scoreText;

    void Update()
    {
        if (player != null)
        {
            scoreText.SetText(player.GetComponent<PlayerController>().points.ToString());
        }
    }
}
