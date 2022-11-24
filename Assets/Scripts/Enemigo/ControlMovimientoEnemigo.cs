using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMovimientoEnemigo : MonoBehaviour
{
    public float rangoDeVision;
    public float rangoAtaque;
    public float velocidadMovimiento;
    public LayerMask capaDelJugador;
    public Transform jugador;
    bool estaAlerta;
    bool enRangoAtaque;
    public bool produceDanio;
    public bool estaAtacando;
    public Animator enemigoAnimator;
    public string variableMovimiento;

    void Start()
    {
        estaAlerta = false;
        estaAtacando = false;
        enRangoAtaque = false;
        produceDanio = false;
        
    }

    
    void Update()
    {
        
        estaAlerta = Physics.CheckSphere(transform.position, rangoDeVision, capaDelJugador);
        enRangoAtaque = Physics.CheckSphere(transform.position, rangoAtaque, capaDelJugador);
        enemigoAnimator.SetFloat(variableMovimiento, 0);
        if (estaAlerta)
        {
            Vector3 posicionJugador = new Vector3(jugador.position.x, transform.position.y, jugador.position.z);
            transform.LookAt(posicionJugador);
            if (!enRangoAtaque && !estaAtacando)
            {
                transform.position = Vector3.MoveTowards(transform.position, posicionJugador, velocidadMovimiento * Time.deltaTime);
                enemigoAnimator.SetFloat(variableMovimiento,1);
            }
            
        }
        if (enRangoAtaque)
        {
            if (!estaAtacando)
            {
                enemigoAnimator.SetTrigger("Ataque");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeVision);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, rangoAtaque);
    }

    public void InicioAtaque()
    {
        estaAtacando = true;
    }
    public void ProducirDanio()
    {
        produceDanio = true;
    }
    public void FinAtaque()
    {
        estaAtacando = false;
        produceDanio = false;
    }
}
