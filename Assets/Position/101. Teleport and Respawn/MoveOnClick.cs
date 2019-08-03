using UnityEngine;

public class MoveOnClick : MonoBehaviour
{
    [SerializeField] private Transform teleportedObject;
    [SerializeField] private Transform target;

    private void OnMouseDown()
    {
        teleportedObject.transform.position = target.position;
    }
}
