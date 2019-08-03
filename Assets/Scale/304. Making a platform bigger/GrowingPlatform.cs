using System.Collections.Generic;
using UnityEngine;

public class GrowingPlatform : MonoBehaviour
{
    private List<Transform> _children = new List<Transform>();

    public void AddChild(Transform transform)
    {
        transform.parent = transform;
        _children.Add(transform);
    }

    public void RemoveChild(Transform transform)
    {
        transform.parent = null;
        _children.Remove(transform);
    }

    public void ParentChildren()
    {
        foreach (var child in _children)
        {
            child.parent = transform;
        }
    }

    public void UnparentChildren()
    {
        foreach (var child in _children)
        {
            child.parent = null;
        }
    }
}

