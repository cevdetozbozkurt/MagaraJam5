using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableManager : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private void FixedUpdate()
    {
        gameObject.transform.Rotate(new Vector3(0,0,speed * Time.deltaTime));
    }
}
