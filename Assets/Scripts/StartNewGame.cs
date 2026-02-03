using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene($"Start");
    }
}
