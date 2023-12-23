using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePointRotation : MonoBehaviour
{
    private Vector2 mousePos;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Camera cam;

    private void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        gameObject.transform.position = gameObject.transform.parent.gameObject.transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
}
