using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaEnemigo;
    public int dañoEnemigo;
    public Slider barraDeVidaEnemigo;
    // Start is called before the first frame update
    void Start()
    {
        vidaEnemigo = 100;
    }

    // Update is called once per frame
    void Update()
    {
        barraDeVidaEnemigo.value = vidaEnemigo;
        if (Input.GetKeyDown("g"))
        {
            vidaEnemigo -= dañoEnemigo;
        }
    }
}
