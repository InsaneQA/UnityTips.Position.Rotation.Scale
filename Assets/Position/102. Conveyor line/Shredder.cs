using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Shredder : MonoBehaviour
{
    [SerializeField] private ConveyorLine _conveyorLine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var figure = collision.GetComponent<Figure>();
        if (figure != null)
        {
            _conveyorLine.RemoveObject(figure);
            Destroy(collision.gameObject);
        }
    }
}
