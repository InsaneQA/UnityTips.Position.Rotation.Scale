using UnityEngine;

public class StartMovingCards : MonoBehaviour
{
    [SerializeField] private DeckPosition _deckPosition;

    private void OnMouseDown()
    {
        _deckPosition.MoveCards();
    }
}
