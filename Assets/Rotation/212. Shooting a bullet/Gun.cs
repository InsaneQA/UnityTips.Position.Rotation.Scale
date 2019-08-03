using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _player;
    [SerializeField] private float _reloadTime;

    private float _timeSinceLastShot = 100f;

    private void Update()
    {
        _timeSinceLastShot += Time.deltaTime;

        if (Input.GetButton("Fire1") && IsReadyToFire())
        {
            ShootBullet();
        }
    }

    private void ShootBullet()
    {
        Instantiate(_bulletPrefab, transform.position, _player.rotation);
        _timeSinceLastShot = 0;
    }

    private bool IsReadyToFire()
    {
        return _timeSinceLastShot >= _reloadTime;
    }
}
