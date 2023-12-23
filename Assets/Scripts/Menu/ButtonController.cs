using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{

    [SerializeField] private Animator[] _animators;
    [SerializeField] private GameObject[] buttons;

    IEnumerator DestroyButtons(GameObject[] buttons)
    {
        foreach (GameObject button in buttons)
        {
            yield return new WaitForSeconds(1f);
            Destroy(button.gameObject);
        }
    }
    
    public void PlayButton()
    {
        foreach (Animator animator in _animators)
        {
            animator.SetBool("isStart", true);
        }

        StartCoroutine(DestroyButtons(buttons));
        StopCoroutine(DestroyButtons(buttons));
    }

    public void OptionsButton()
    {
        
    }

    public void CreditsButton()
    {
        
    }
    
    public void ExitButton()
    {
        Application.Quit(1);
    }
    
}
