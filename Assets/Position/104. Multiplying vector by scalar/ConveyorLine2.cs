using System.Collections.Generic;
using UnityEngine;

public class ConveyorLine2 : MonoBehaviour
{
    [SerializeField]
    private float _speed = 1f;

    public List<Figure> Figures { get; private set; }

    private void Awake()
    {
        Figures = new List<Figure>();
    }

    private void Update()
    {
        if (Figures.Count.Equals(0))
        {
            return;
        }


        for (int i = 0; i < Figures.Count; i++)
        {
            MoveFigure(i);
        }
    }

    public void AddObject(Figure figure)
    {
        figure.transform.SetParent(transform, worldPositionStays: true);
        Figures.Add(figure);
    }

    public void RemoveObject(Figure figure)
    {
        Figures.Remove(figure);
    }

    private void MoveFigure(int figureIndex)
    {
        // Now we are using Time.deltaTime and the speed value set in the Inspector
        var vector = -transform.up * _speed * Time.deltaTime;
        Figures[figureIndex].transform.Translate(vector, Space.Self);
    }


}
