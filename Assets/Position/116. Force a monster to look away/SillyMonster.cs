using UnityEngine;

public class SillyMonster : MonoBehaviour
{
    [SerializeField] private float _viewAngle = 60f;

    private Distraction _distraction;

    public PlayerForSillyMonster _player;
    public PlayerForSillyMonster Target { get; set; }

    public void Start()
    {
        _player = FindObjectOfType<PlayerForSillyMonster>();
        _distraction = GetComponent<Distraction>();
    }

    public void Update()
    {
        SearchForPlayer();
    }

    private void SearchForPlayer()
    {
        var vectorToPlayer = _player.transform.position - transform.position;
        var expectedDot = Mathf.Cos((_viewAngle / 2) * Mathf.PI / 180);
        var actualDot = Vector2.Dot(transform.up.normalized, vectorToPlayer.normalized);
        Debug.Log("actual dot" + actualDot + ", expected dot " + expectedDot);
        if (actualDot >= expectedDot)
        {
            CheckIfPlayerIsVisible();
            CheckForDistraction();
        }
    }

    private void CheckForDistraction()
    {
        if (Target == null && _distraction.ShouldBeDistracted())
        {
            _distraction.Distract(this);
        }
    }

    private void CheckIfPlayerIsVisible()
    {
        var layerMask = LayerMask.GetMask("Wall");
        var vectorToPlayer = _player.transform.position - transform.position;
        var hit = Physics2D.Raycast(transform.position, vectorToPlayer, vectorToPlayer.magnitude, layerMask);

        if (hit.collider != null)
        {
            Target = null;
        }
        else
        {
            Target = _player;
        }
    }
}
