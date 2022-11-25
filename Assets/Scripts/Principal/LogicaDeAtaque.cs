using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaDeAtaque : MonoBehaviour
{
    public Animator principalAnimator;
    public ControlDelPersonaje principalControl;
    bool puedeAtacar;
    public bool puedeDaniar;
    public ControlDeVida vidaJugador;
    
    
    void Start()
    {
        puedeAtacar = true;
        puedeDaniar = false;
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
        vidaJugador.puedeRecibirDanio = false;
    }

    public void DejaDeAtacar()
    {
        principalControl.puedeMoverse = true;
        puedeAtacar = true;
        vidaJugador.puedeRecibirDanio = true;
    }
    public void Danio()
    {
        puedeDaniar = true;
        
    } 
    public void Danio2()
    {
        puedeDaniar = false;
       
    }


}
