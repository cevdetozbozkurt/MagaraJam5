using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;

        // Load main menu
        SceneManager.LoadScene(0);
    }
}
