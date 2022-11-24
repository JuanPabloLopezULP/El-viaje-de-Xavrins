using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaEnemigo;
    public int danioEnemigo;
    public bool puedeRecibirDanio;
    public Animator enemigoAnimator;
    public ControlMovimientoEnemigo enemigoController;
    public Slider barraDeVidaEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigo = 100;
        danioEnemigo = 10;
        puedeRecibirDanio = true;
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVidaEnemigo.value = vidaEnemigo;
        if (Input.GetKeyDown("g"))
        {
            RecibirDanio();
        }
        
        if (vidaEnemigo == 0)
        {
            enemigoAnimator.SetTrigger("Muere");
            
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ArmaPrincipal"))
        {
            Debug.Log("daño al enemigo");
        }
    }
}
