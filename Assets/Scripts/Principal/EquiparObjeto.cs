using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquiparObjeto : MonoBehaviour
{
    public Animator principalAnimator;
    public ControlDelPersonaje principalControl;
    bool puedeInteractuar;

    public Caja caja;
    // Start is called before the first frame update
    void Start()
    {
        puedeInteractuar = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire2") && caja.rangoAccion && caja.cajaAbierta && puedeInteractuar)
        {
            principalAnimator.SetTrigger("TomarObjeto");
        }
    }

    public void InicioObj()
    {
        principalControl.puedeMoverse = false;
        puedeInteractuar = false;
    }
    public void FinObj()
    {
        principalControl.puedeMoverse = true;
        puedeInteractuar = true;

    }
}
