using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RandomDirectionGenerator : MonoBehaviour
{
    [SerializeField] private float _possibilityChange;

    private Dictionary<PossibleDirections, float> _possibilities = new Dictionary<PossibleDirections, float>();

    public void UpdateTheDirectionPossibilities(PossibleDirections directionToPlayer)
    {
        _possibilities[directionToPlayer] -= _possibilityChange;
    }

    public PossibleDirections GetRandomTargetDirection()
    {
        float cumulativeSum = 0f;
        float valuesSum = _possibilities.Values.Sum();

        // Random number from 0 to the sum of all possibilities
        float randomNumber = Random.Range(0, valuesSum);

        foreach (var key in _possibilities.Keys)
        {
            cumulativeSum += _possibilities[key];

            if (randomNumber <= cumulativeSum)
            {
                return key;
            }
        }

        throw new System.Exception("Something went wrong with the possibilies. randomNumber = " + randomNumber + ", cumulativeSum = " + cumulativeSum);
    }

    public void GenerateDirectionPossibilities(PossibleDirections possibleDirections)
    {
        ClearState();

        var directionsCount = MonsterDirection.CountPossibleDirections(possibleDirections);
        var equalPosibility = 1f / directionsCount;

        if ((possibleDirections & PossibleDirections.Up) == PossibleDirections.Up)
        {
            _possibilities.Add(PossibleDirections.Up, equalPosibility);
        }

        if ((possibleDirections & PossibleDirections.Down) == PossibleDirections.Down)
        {
            _possibilities.Add(PossibleDirections.Down, equalPosibility);
        }

        if ((possibleDirections & PossibleDirections.Left) == PossibleDirections.Left)
        {
            _possibilities.Add(PossibleDirections.Left, equalPosibility);
        }

        if ((possibleDirections & PossibleDirections.Right) == PossibleDirections.Right)
        {
            _possibilities.Add(PossibleDirections.Right, equalPosibility);
        }
    }

    private void ClearState()
    {
        _possibilities.Clear();
    }
}

