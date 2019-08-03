using TMPro;
using UnityEngine;

public class LossyScale : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private TextMeshPro _label;

    // Update is called once per frame
    private void Update()
    {
        _label.text = _transform.lossyScale.ToString();
    }
}
