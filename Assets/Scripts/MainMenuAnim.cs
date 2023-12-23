using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    [SerializeField] private int speed = 20;
    private void Update()
    {
        gameObject.transform.Rotate(new Vector3(0,0, speed * Time.deltaTime));
    }
}
