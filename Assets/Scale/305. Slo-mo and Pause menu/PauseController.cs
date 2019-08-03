using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseBackground;

    public void Pause()
    {
        Pause(true);
    }

    public void UnPause()
    {
        Pause(false);
    }

    private void Pause(bool isPaused)
    {
        Time.timeScale = (isPaused) ? 0f : 1f;
        _pauseBackground.SetActive(isPaused);
    }

    private void OnDestroy()
    {
        Pause(false);
    }
}

