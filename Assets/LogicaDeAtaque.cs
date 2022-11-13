using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDeAtaque : MonoBehaviour
{
    public Animator principalAnimator;
    public ControlDelPersonaje principalControl;
    bool puedeAtacar;
    void Start()
    {
        puedeAtacar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")&& principalControl.estaEnElSuelo && puedeAtacar)
        {
            principalAnimator.SetTrigger("Ataca");
        }
    }

    public void Ataca()
    {
        principalControl.puedeMoverse = false;
        puedeAtacar = false;
    }

    public void DejaDeAtacar()
    {
        principalControl.puedeMoverse = true;
        puedeAtacar = true;
    }
}
