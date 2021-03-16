using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]
public class Parallax : MonoBehaviour
{
    [SerializeField] private float _speedScale;
    [SerializeField] private Rigidbody2D _target;

    private RawImage _image;
    private float _width;

    private void Awake()
    {
        _image = GetComponent<RawImage>();
        _width = GetWidth();
    }

    private void FixedUpdate()
    {
        float speed = _target.velocity.x / _width * _speedScale;
        if (_image.uvRect.x > 10)
            _image.uvRect = new Rect(new Vector2(0, _image.uvRect.y), _image.uvRect.size);

        _image.uvRect = new Rect(_image.uvRect.position + Vector2.right * speed * Time.fixedDeltaTime, _image.uvRect.size);
    }

    private float GetWidth()
    {
        return Mathf.Abs(Camera.main.ScreenToWorldPoint(Camera.main.transform.position).x * 2);
    }
}
