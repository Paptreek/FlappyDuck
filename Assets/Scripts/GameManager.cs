using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject obstacle;

    public GameObject gameOverPanel;
    public GameObject pausedText;
    public TMP_Text _scoreText;
    public TMP_Text _highScoreText;

    private int _currentScore;
    private int _highScore;
    private bool _paused;

    void Update()
    {
        if (player != null)
        {
            _currentScore = player.GetComponent<PlayerController>().points;
            _scoreText.SetText(_currentScore.ToString());

            if (_currentScore > _highScore)
            {
                SetHighScore("HighScore", _currentScore);
                //_highScore = _currentScore;
            }

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
            _highScoreText.SetText(GetHighScore("HighScore").ToString());
            gameOverPanel.gameObject.SetActive(true);
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

    private void SetHighScore(string KeyName, int Value)
    {
        PlayerPrefs.SetInt(KeyName, Value);
    }

    private int GetHighScore(string KeyName)
    {
        return PlayerPrefs.GetInt(KeyName);
    }
}
