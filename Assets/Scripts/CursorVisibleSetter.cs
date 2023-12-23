using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorVisibleSetter : MonoBehaviour
{
    [SerializeField] private bool defaultVisible = false;
    
    private void Awake()
    {
        Cursor.visible = defaultVisible;
    }
}
