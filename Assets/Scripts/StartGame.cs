using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void OnJump()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
