﻿using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody _rigidbody;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _speed = 3;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Update()
    {
        var strafe = Input.GetAxis("Horizontal");
        var forward = Input.GetAxis("Vertical");

        var movementVelocity = new Vector3(strafe, 0, forward);

        // Say "No" to straferunning!
        movementVelocity.Normalize();

        movementVelocity *= _speed;

        // TransformDirection method translate a vector from the world scale to the local scale
        // It will be explained later (but you can play around with it if you want:))
        movementVelocity = _camera.transform.TransformDirection(movementVelocity);

        // Here we add the falling velocity. Without it, the object would fall slooooowly...
        movementVelocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = movementVelocity;
    }
}
