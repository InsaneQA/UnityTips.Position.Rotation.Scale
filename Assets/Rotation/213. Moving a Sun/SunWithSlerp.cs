using UnityEngine;

public class SunWithSlerp : RotationDemo
{
    protected override void Rotate()
    {
        //var percent = Mathf.Clamp01(_rotationPercent);
        //transform.rotation = Quaternion.Slerp(_startRotation, _endRotation, percent);

        transform.rotation = Quaternion.Slerp(_startRotation, _endRotation, _rotationPercent);
    }
}

