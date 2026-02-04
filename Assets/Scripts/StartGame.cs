using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    void OnJump()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
