using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Caja : MonoBehaviour
{
    
    public Image mensajeCaja;
    public Image mensajeItem;
    public bool rangoAccion;
    public Animator cajaAnimator;
    public GameObject item;
    public bool cajaAbierta;
    public ControlDeVida controlVida;
    bool hayItem;

    void Start()
    {
        mensajeCaja.enabled = false;
        mensajeItem.enabled = false;
        rangoAccion = false;
        cajaAbierta = false;
        hayItem = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2") && rangoAccion && !cajaAbierta)
        {
            mensajeCaja.enabled = false;
            cajaAbierta = true;
            cajaAnimator.SetTrigger("AbrirCaja");

        }
        if (Input.GetButtonDown("Fire2") && rangoAccion && cajaAbierta && hayItem)
        {
            mensajeItem.enabled = false;
            controlVida.botellasEquipadas += 1;
            StartCoroutine(SecuenciaDestruccion());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Principal") && !cajaAbierta)
        {
            mensajeCaja.enabled = true;
            rangoAccion = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Principal") && cajaAbierta)
        {
            mensajeItem.enabled = true;
            rangoAccion = true;
            if (!hayItem)
            {
                mensajeItem.enabled = false;
                rangoAccion = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Principal")&&!cajaAbierta)
        {
            mensajeCaja.enabled = false;
            rangoAccion = false;
        }

        if (other.CompareTag("Principal") && cajaAbierta)
        {
            mensajeItem.enabled = false;
            rangoAccion = false;
        }
    }

    private void InstanciarItem()
    {
        item = Instantiate(item.gameObject);
        hayItem = true;
    }

    IEnumerator SecuenciaDestruccion()
    {
        yield return new WaitForSecondsRealtime(0.7f);
        Destroy(item.gameObject);
        hayItem = false;
        yield return null;
    }

}
