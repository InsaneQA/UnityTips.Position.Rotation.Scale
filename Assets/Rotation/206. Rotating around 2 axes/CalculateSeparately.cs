using UnityEngine;

public class CalculateSeparately : MonoBehaviour
{
    [SerializeField] private int xSpeed = 5;
    [SerializeField] private int ySpeed = 5;

    private Quaternion rotationX = Quaternion.identity;
    private Quaternion rotationY = Quaternion.identity;

    private void Update()
    {

        rotationX *= Quaternion.Euler(xSpeed * Time.deltaTime, 0, 0);
        rotationY *= Quaternion.Euler(0, ySpeed * Time.deltaTime, 0);
        //transform.rotation = rotationX * rotationY; // Not the right order!
        transform.rotation = rotationY * rotationX; // Correct order
    }
}
