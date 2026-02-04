using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject obstacle;

    public TMP_Text scoreText;
    public GameObject gameOverText;
    public GameObject pausedText;
    public Button playAgainButton;

    private bool _paused;
    private bool _muted;

    void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            ToggleMute();
        }

        if (player != null)
        {
            scoreText.SetText(player.GetComponent<PlayerController>().points.ToString());

            if (Keyboard.current.escapeKey.wasPressedThisFrame && _paused == false)
            {
                PauseGame();
            }
            else if (Keyboard.current.escapeKey.wasPressedThisFrame && _paused == true)
            {
                ResumeGame();
            }
        }
        else
        {
            gameOverText.gameObject.SetActive(true);
            playAgainButton.gameObject.SetActive(true);
        }
    }

    private void PauseGame()
    {
        pausedText.gameObject.SetActive(true);
        player.GetComponent<PlayerController>().canJump = false;
        Time.timeScale = 0;
        AudioListener.pause = true;
        _paused = true;
    }

    private void ResumeGame()
    {
        pausedText.gameObject.SetActive(false);
        player.GetComponent<PlayerController>().canJump = true;
        Time.timeScale = 1;
        AudioListener.pause = false;
        _paused = false;
    }

    private void ToggleMute()
    {
        if (!_muted)
        {
            AudioListener.volume = 0;
            _muted = true;
        }
        else
        {
            AudioListener.volume = 1;
            _muted = false;
        }
    }
}
