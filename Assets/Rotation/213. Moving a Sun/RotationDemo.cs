using UnityEngine;

public abstract class RotationDemo : MonoBehaviour
{
    protected Quaternion _startRotation;
    protected Quaternion _endRotation;
    protected float _rotationPercent = 0f;
    protected float _rotationDiration = 10f;

    protected void Awake()
    {
        _startRotation = transform.rotation;
        _endRotation = _startRotation * Quaternion.Euler(0f, 0f, 180f);
    }

    // The template method pattern is used here: the concrete classes will only change the Rotate() method;
    // The concrete classes don't need to override the Update method
    protected void Update()
    {
        Debug.Log(this.GetType().ToString());
        Rotate();
        _rotationPercent += Time.deltaTime / _rotationDiration;
    }

    protected abstract void Rotate();
}

