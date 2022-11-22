using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correr : MonoBehaviour
{
    public Animator principalAnimator;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire3"))
        {
            principalAnimator.SetTrigger("Corre");
        }
        if (Input.GetButtonUp("Fire3"))
        {
            principalAnimator.SetTrigger("NoCorre");
        }
    }
    
}
