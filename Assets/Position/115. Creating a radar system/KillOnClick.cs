using UnityEngine;

public class KillOnClick : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
