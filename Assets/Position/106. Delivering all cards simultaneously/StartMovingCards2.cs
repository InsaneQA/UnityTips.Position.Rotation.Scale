using UnityEngine;

public class StartMovingCards2 : MonoBehaviour
{
    [SerializeField] private DeckPosition2 _deckPosition;

    private void OnMouseDown()
    {
        _deckPosition.MoveCards();
    }
}
