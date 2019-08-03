using UnityEngine;

public class JumpScript : MonoBehaviour
{
    public bool CanJump { get; private set; }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            CanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag.Equals("Ground"))
        {
            CanJump = false;
        }
    }
}
