using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 borderLimit = new Vector2(15f, 8f);
    [SerializeField] private float scrollSpeed = 5;

    private Camera _camera;
    private Vector2 centerPos = new Vector2(6.5f, 3.5f);
    private float sizeDef = 8;
    public float coef;

    // Start is called before the first frame update
    private void Start()
    {
        _camera = Camera.main;
    }


    // Update is called once per frame
    void Update()
    {
        float size = _camera.orthographicSize;
        if (_camera.orthographic)
        {
            size -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
            size = Mathf.Clamp(size, 1, 20);
            _camera.orthographicSize = size;
        }
        else
        {
            _camera.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * scrollSpeed;
        }
        
        Vector3 pos = transform.position;
        if (Input.GetMouseButton(0))
        {
            if (Input.GetAxis("Mouse X") != 0)
            {
                pos -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * moveSpeed,
                    Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * moveSpeed, 0.0f);
                pos.x = Mathf.Clamp(pos.x,  -borderLimit.x + centerPos.x, borderLimit.x + centerPos.x);
                pos.y = Mathf.Clamp(pos.y,  -borderLimit.y + centerPos.y, borderLimit.y + centerPos.y);
               transform.position = pos;
            }
        }
    }
}
