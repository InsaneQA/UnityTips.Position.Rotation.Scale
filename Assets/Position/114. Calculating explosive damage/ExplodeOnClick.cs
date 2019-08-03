using UnityEngine;

public class ExplodeOnClick : MonoBehaviour
{
    [SerializeField] private Bomb _bomb;

    private void OnMouseDown()
    {
        _bomb.Explode();
        Destroy(_bomb.gameObject);
    }
}

