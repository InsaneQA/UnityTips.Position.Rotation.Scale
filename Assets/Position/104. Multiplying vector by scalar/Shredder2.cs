using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Shredder2 : MonoBehaviour
{
    [SerializeField] private ConveyorLine2 _conveyorLine;

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
