using UnityEngine;

public class SunWithLerp : RotationDemo
{
    protected override void Rotate()
    {
        //var percent = Mathf.Clamp01(_rotationPercent);
        //transform.rotation = Quaternion.Lerp(_startRotation, _endRotation, percent);

        transform.rotation = Quaternion.Lerp(_startRotation, _endRotation, _rotationPercent);
    }
}
