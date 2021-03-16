using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _force;
    [SerializeField] private float _maxAngle;
    [SerializeField] private float _minAngle;

    private Rigidbody2D _rigidBody;
    private Animator _animator;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;
    private Vector2 _startPosition;

    private void Awake()
    {
        _startPosition = transform.position;
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _maxRotation = Quaternion.Euler(0, 0, _maxAngle);
        _minRotation = Quaternion.Euler(0, 0, _minAngle);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidBody.velocity = Vector2.right * _speed;
            transform.rotation = _maxRotation;
            _rigidBody.AddForce(Vector2.up * _force, ForceMode2D.Force);
            _animator.SetTrigger("Flap");
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        _rigidBody.velocity = Vector2.right * _speed;
    }
}
