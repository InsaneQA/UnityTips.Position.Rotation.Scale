using UnityEngine;

public class TrackedEnemy : MonoBehaviour
{
    private RadarGameManager _gameManager;

    private void Start()
    {
        _gameManager = FindObjectOfType<RadarGameManager>();
    }

    private void OnDestroy()
    {
        _gameManager.RemoveEnemy(this);
    }
}
