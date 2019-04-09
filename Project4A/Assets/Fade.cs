using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var faded = animator.GetBool("Faded");
            animator.SetBool("Faded", !faded);
        }
    }

    public void PrintMessage()
    {
        Debug.Log("Fade half done");
    }
}
