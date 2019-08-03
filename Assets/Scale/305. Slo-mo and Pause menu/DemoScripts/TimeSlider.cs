using UnityEngine;

public class TimeSlider : MonoBehaviour
{
    public void Slider_Changed(float timeScale)
    {
        Time.timeScale = timeScale;
    }
}
