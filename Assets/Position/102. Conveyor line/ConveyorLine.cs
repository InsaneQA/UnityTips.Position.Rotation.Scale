using System.Collections.Generic;
using UnityEngine;

public class ConveyorLine : MonoBehaviour
{
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
        // The vector should be multiplyed by Time.deltaTime, but we'll do it in the
        // next lecture. Stay tuned!
        var vector = Vector2.down;
        Figures[figureIndex].transform.Translate(vector);
    }


}
