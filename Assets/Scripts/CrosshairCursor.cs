using System;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class CrosshairCursor : MonoBehaviour
{
    private Animator _animator;
    private bool isButtonDown;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        Cursor.visible = false;
    }

    private void Update()
    {
        isButtonDown = Input.GetMouseButtonDown(0);
        if (isButtonDown)
        {
            _animator.SetBool("isFire", true);
        }
        else
        {
            _animator.SetBool("isFire", false);
        }
    }

    private void FixedUpdate()
    {
        Vector2 mouseCursorPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mouseCursorPos;
        
    }
}
