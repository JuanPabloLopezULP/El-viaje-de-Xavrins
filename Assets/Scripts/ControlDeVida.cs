using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlDeVida : MonoBehaviour
{
    public Animator principalAnimator;
    public ControlDelPersonaje principalControl;
    public int salud;
    public int botellasEquipadas;
    public Slider barraDeVida;
    bool puedeRecibirDanio;
    public UsarMedicina item;
    void Start()
    {
        salud = 100;
        botellasEquipadas = 0;
        puedeRecibirDanio = true;
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVida.value = salud;
        if (Input.GetKeyDown("t")&&puedeRecibirDanio)
        {

            principalAnimator.SetTrigger("RecibeDaño");
            RestarSalud();
            Debug.Log("salud = " + salud);
        }
        if (Input.GetKeyDown("e") && botellasEquipadas>0)
        {
            UsarMedicina();
            principalAnimator.SetTrigger("Bebe");
            Debug.Log("salud = " + salud);
        }
        if (salud == 0)
        {
            principalAnimator.SetTrigger("Muere");
            principalControl.puedeMoverse = false;
        }
    }

    public void RestarSalud()
    {
        if (salud > 0)
        {
            salud -= Mathf.Min(salud,10);
            
        }
    }
    public void UsarMedicina()
    {
        if (salud < 100)
        {
            salud += Mathf.Min((100 - salud), 30);
            botellasEquipadas -= 1;
        }

    }

    public void RecibeDanio()
    {
        
        principalControl.puedeMoverse = false;
        puedeRecibirDanio = false;
    }
    public void DejaDeRecibirDanio()
    {
        principalControl.puedeMoverse = true;
        puedeRecibirDanio = true;
    }

    public void InicioBebe()
    {
        principalControl.puedeMoverse = false;


    }
    public void FinBebe()
    {
        principalControl.puedeMoverse = true;

       
    }
}
