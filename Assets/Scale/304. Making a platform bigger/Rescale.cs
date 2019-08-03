using UnityEngine;

public class Rescale : MonoBehaviour
{
    [SerializeField] private float _scaleFactor;
    [SerializeField] private float _sizeChangeDuration;
    [SerializeField] private GrowingPlatform _growingPlatform;

    private Vector3 _targetScaleVector;
    private Vector3 _initialScaleVector;
    private bool _isGrowing = false;

    private float _currentScalePercent;
    public bool IsChanging { get; set; }

    private void Update()
    {
        if (IsChanging)
        {
            _growingPlatform.UnparentChildren();
            ChangeSize();
            _growingPlatform.ParentChildren();
        }
        else
        {
            SetNewInitialScaleVector();
            SetNewTargetScaleVector();
            IsChanging = true;
        }
    }

    private void Start()
    {
        // It is easier to calculate the step for scale change at the beginning of the game
        _currentScalePercent = (_scaleFactor - transform.localScale.x) / _sizeChangeDuration;
    }

    private void SetNewInitialScaleVector()
    {
        _initialScaleVector = transform.localScale;
    }

    private void SetNewTargetScaleVector()
    {
        _isGrowing = !_isGrowing;

        if (_isGrowing)
        {
            _targetScaleVector = transform.localScale * _scaleFactor;
        }
        else
        {
            _targetScaleVector = transform.localScale / _scaleFactor;
        }
    }

    private void ChangeSize()
    {
        if (ScalingIsDone())
        {
            IsChanging = false;
            _currentScalePercent = 0;
            return;
        }

        _currentScalePercent += Time.deltaTime / _sizeChangeDuration;
        _currentScalePercent = Mathf.Clamp01(_currentScalePercent);

        var newScaleX = Mathf.Lerp(_initialScaleVector.x, _targetScaleVector.x, _currentScalePercent);
        var newScaleY = Mathf.Lerp(_initialScaleVector.y, _targetScaleVector.y, _currentScalePercent);
        var newScaleZ = Mathf.Lerp(_initialScaleVector.z, _targetScaleVector.z, _currentScalePercent);
        transform.localScale = new Vector3(newScaleX, newScaleY, newScaleZ);
    }

    private bool ScalingIsDone()
    {
        return _currentScalePercent.Equals(1);
    }
}
