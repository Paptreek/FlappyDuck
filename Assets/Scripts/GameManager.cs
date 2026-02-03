using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject obstacle;

    public TMP_Text scoreText;
    public GameObject gameOverText;
    public Button playAgainButton;

    void Update()
    {
        if (player != null)
        {
            scoreText.SetText(player.GetComponent<PlayerController>().points.ToString());
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
            playAgainButton.gameObject.SetActive(true);
        }
    }
}
