using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    //private float moveSpeed = 10f;
    private Vector2 borderLimit = new Vector2(18f, 8f);
    [SerializeField] private float scrollSpeed = 5;

    private Vector3 dragOrigin;
    private Camera _camera;
    private Vector2 centerPos = new Vector2(6.5f, 3.5f);
    public float coef;

    // Start is called before the first frame update

    private void Awake()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1; //CAUTION
        }
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        
        // if (Input.GetMouseButton(0) && !IsMouseOverUI())
        // {
        //     if (Input.GetAxis("Mouse X") != 0)
        //     {
        //         pos -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * moveSpeed,
        //             Input.GetAxisRaw("Mouse Y") * Time.deltaTime * moveSpeed, 0.0f);
        //         pos.x = Mathf.Clamp(pos.x,  -borderLimit.x + centerPos.x, borderLimit.x + centerPos.x);
        //         pos.y = Mathf.Clamp(pos.y,  -borderLimit.y + centerPos.y, borderLimit.y + centerPos.y);
        //        transform.position = pos;
        //     }
        // }
        if (!IsMouseOverUI())
        {
            ZoomCamera();
            PanCamera();
        }
    }

    private void ZoomCamera()
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
    }

    private void PanCamera()
    {
        if (Input.GetMouseButtonDown(0))
        {
            dragOrigin = _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 difference = dragOrigin - _camera.ScreenToWorldPoint(Input.mousePosition);
            _camera.transform.position += difference;
        }
    }
    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }
}
