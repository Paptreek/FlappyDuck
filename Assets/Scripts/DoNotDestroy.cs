using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class DoNotDestroy : MonoBehaviour
{
    private bool _muted;

    void Start()
    {
        DoNotDestroy.DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("Start");
    }

    private void Update()
    {
        if (Keyboard.current.mKey.wasPressedThisFrame)
        {
            ToggleMute();
        }
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
