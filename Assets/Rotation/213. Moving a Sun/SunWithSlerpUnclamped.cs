using UnityEngine;

public class SunWithSlerpUnclamped : RotationDemo
{
    protected override void Rotate()
    {
        transform.rotation = Quaternion.SlerpUnclamped(_startRotation, _endRotation, _rotationPercent);
    }
}
