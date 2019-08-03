using UnityEngine;

public class CardCoordinates : MonoBehaviour
{
    [SerializeField] private Vector3 startingCoordinates;
    [SerializeField] private float offset;
    [SerializeField] private Vector3[] coordinates;

    public Vector3[] Coordinates
    {
        get
        {
            return coordinates;
        }
    }

    private void Awake()
    {
        for (int i = 0; i < coordinates.Length; i++)
        {
            coordinates[i] = new Vector3(startingCoordinates.x + (i * offset), startingCoordinates.y, -i * 0.1f);
        }
    }
}
