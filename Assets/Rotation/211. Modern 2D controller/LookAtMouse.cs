using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    [SerializeField] private LookMethod _lookMethod = LookMethod.TransformLookAt;
    private Vector2 _cursorPositionRelativeToPlayer;

    public void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        _cursorPositionRelativeToPlayer = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        _cursorPositionRelativeToPlayer = Camera.main.ScreenToWorldPoint(Input.getTouch(0)) - transform.position;
#endif

        Rotate();
    }

    private void Rotate()
    {
        switch (_lookMethod)
        {
            case LookMethod.TransformLookAt:
                transform.LookAt(transform.position - Vector3.forward, _cursorPositionRelativeToPlayer);
                break;
            case LookMethod.QuaternionLookRotation:
                transform.rotation = Quaternion.LookRotation(Vector3.forward, _cursorPositionRelativeToPlayer);
                break;
            case LookMethod.QuaternionFromToRotation:
                transform.rotation = Quaternion.FromToRotation(Vector2.up, _cursorPositionRelativeToPlayer);
                break;

        }
    }

    private enum LookMethod
    {
        TransformLookAt,
        QuaternionLookRotation,
        QuaternionFromToRotation
    }
}

