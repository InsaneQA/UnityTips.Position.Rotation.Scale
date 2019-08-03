using UnityEngine;

public class QuaternionConstructor : MonoBehaviour
{
    private void Start()
    {
        var quaternion1 = new Quaternion(1f, 1f, 0.5f, 0.5f); // This will create a weird quaternion
        var quaternion2 = new Quaternion(1f, 2f, 3f, 4f); // This will fail

        quaternion1.Normalize(); // Don't forget to normalize the manually created quaternions
    }
}

