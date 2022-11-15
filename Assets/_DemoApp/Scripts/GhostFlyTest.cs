using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFlyTest : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator animator;
    // Use this for initialization
    void Start()
    {
        animator = this.transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && animator == true)
        {
            animator.SetBool("FlyBool", true);
        }

    }
   
}
