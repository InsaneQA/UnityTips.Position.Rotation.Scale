using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    private void Update()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        var cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        cursorPosition = Camera.main.ScreenToWorldPoint(Input.getTouch(0));
#endif
        cursorPosition.Set(cursorPosition.x, cursorPosition.y, 0);
        transform.position = cursorPosition;
    }
}
