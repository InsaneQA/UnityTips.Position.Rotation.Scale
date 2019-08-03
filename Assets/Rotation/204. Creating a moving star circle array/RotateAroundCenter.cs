using UnityEngine;

public class RotateAroundCenter : MonoBehaviour
{
    [SerializeField] private float _speed;
    public GameObject Center { get; set; }

    /* 
     * This script is a bonus!
     * Rotating each star around the center is less efficient than rotating the center object,
     * so I disable the script that do that. You can still use it if you want (don't forget to disable
     * the ArrayRotation script in that case!) 
     */

    public void Update()
    {
        transform.RotateAround(Center.transform.position, Center.transform.forward, _speed * Time.deltaTime);
    }
}


