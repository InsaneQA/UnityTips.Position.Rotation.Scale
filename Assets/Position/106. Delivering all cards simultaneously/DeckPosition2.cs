using UnityEngine;

public class DeckPosition2 : MonoBehaviour
{
    [SerializeField] private MovingCard2[] cards;
    [SerializeField] private CardCoordinates2 deckCoordinates;
    [SerializeField] private CardCoordinates2 targetCoordinates;

    private void Start()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = deckCoordinates.Coordinates[i];
            cards[i].TargetPosition = targetCoordinates.Coordinates[i];
            cards[i].InitialPosition = cards[i].transform.position;
        }
    }

    public void MoveCards()
    {
        foreach (var card in cards)
        {
            card.IsMoving = true;
        }
    }
}
