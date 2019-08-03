using UnityEngine;

public class DeckPosition : MonoBehaviour
{
    [SerializeField] private MovingCard[] cards;
    [SerializeField] private CardCoordinates deckCoordinates;
    [SerializeField] private CardCoordinates targetCoordinates;

    private void Start()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = deckCoordinates.Coordinates[i];
            cards[i].TargetPosition = targetCoordinates.Coordinates[i];
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
