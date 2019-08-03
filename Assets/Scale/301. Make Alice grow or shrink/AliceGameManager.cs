using UnityEngine;

public class AliceGameManager : MonoBehaviour
{
    [SerializeField] private float _raycastDistance;
    [SerializeField] private Alice _alice;
    [SerializeField] private float _scaleFactor;
    [SerializeField] private float _sizeChangeDuration;
    private float _currentScale;
    private float _percent = 0;

    private void Start()
    {
        _currentScale = _alice.transform.localScale.x;
    }

    private void Update()
    {
        if (_alice.IsChanging)
        {
            ChangeSize();
            return; // No need to check for the user input if Alice is still changing her size
        }

        if (Input.GetButton("Fire1") && !_alice.IsChanging)
        {
            var collider = GetColliderFromRaycast();
            ModifyAliceTargetScale(collider);
        }
    }

    private void ModifyAliceTargetScale(Collider collider)
    {
        if (collider == null)
        {
            return;
        }

        if (collider.tag.Equals("Shrink"))
        {
            _alice.TargetScale = _alice.transform.localScale.x / _scaleFactor;
            _alice.IsChanging = true;
        }

        if (collider.tag.Equals("Grow"))
        {
            _alice.TargetScale = _alice.transform.localScale.x * _scaleFactor;
            _alice.IsChanging = true;
        }
    }

    private Collider GetColliderFromRaycast()
    {
        var cameraPosition = Camera.main.transform.position;

        // 1f is a distance from the main camera.If z is not changed, the ray will not hit any object
        var mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1f));
        RaycastHit hit;
        var raycastDirection = mousePosition - cameraPosition;
        Physics.Raycast(cameraPosition, raycastDirection, out hit, _raycastDistance);

        return hit.collider;
    }

    private void ChangeSize()
    {
        if (_alice.TargetScale == _alice.transform.localScale.x)
        {
            _alice.IsChanging = false;
            _currentScale = _alice.transform.localScale.x;
            _percent = 0;
            return;
        }

        var newScale = Mathf.Lerp(_currentScale, _alice.TargetScale, _percent);
        _alice.transform.localScale = new Vector3(newScale, newScale, newScale);
        _percent += Time.deltaTime / _sizeChangeDuration;
    }
}
