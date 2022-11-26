using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaEnemigo;
    public int danioEnemigo;
    public bool puedeRecibirDanio;
    public bool puedeMoverse;
    public Animator enemigoAnimator;
    public ControlMovimientoEnemigo enemigoController;
    public Slider barraDeVidaEnemigo;
    public  LogicaDeAtaque ataquePrincipal;
    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigo = 100;
        danioEnemigo = 30;
        puedeRecibirDanio = true;
        puedeMoverse = true;
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVidaEnemigo.value = vidaEnemigo;
        
        if (vidaEnemigo == 0)
        {
            enemigoAnimator.SetTrigger("Muere");
            puedeRecibirDanio = false;
            puedeMoverse = false;
        }
    }

    public void RecibirDanio()
    {
        if (vidaEnemigo > 0)
        {
            vidaEnemigo -= Mathf.Min(vidaEnemigo, danioEnemigo);
            enemigoAnimator.SetTrigger("Daño");
        }
    }

    public void Reanudar()
    {
        enemigoController.estaAtacando = false;
    }

    public void InicioDañoEnemigo()
    {
        puedeRecibirDanio = false;
    }

    public void FinDañoEnemigo()
    {
        puedeRecibirDanio = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("ArmaPrincipal")&& ataquePrincipal.puedeDaniar)
        {
            if (puedeRecibirDanio)
            {
                RecibirDanio();
            }
        }
    }
    
}
