using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlDelPersonaje : MonoBehaviour
{
    [Header("Variables Movimiento Del Personaje")]
    public CharacterController controlador;
    public Transform camara;
    public float velocidadDeMovimiento;
    private float rotacionSuave = 0.1f;
    float velocidadRotacionSuave;


    [Header("Variables Salto y Suelo")]

    public Transform chequeadorDeSuelo;
    public float distanciaAlSuelo;
    public LayerMask mascaraDeSuelo;

    Vector3 velocidad;
    public bool estaEnElSuelo;
    public float gravedad = -9.81f;
    public float alturaDelSalto;

    //Animacion
    [Header("Variables de Animaci�n")]
    public Animator animator;


    public string variableMovimiento;
    public string variableSuelo;
    public bool puedeMoverse;



    void Start()
    {
        controlador = GetComponent<CharacterController>();
        puedeMoverse = true;
    }

    void Update()
    {

        if (puedeMoverse)
        {
            estaEnElSuelo = Physics.CheckSphere(chequeadorDeSuelo.position, distanciaAlSuelo, mascaraDeSuelo);
            if (estaEnElSuelo && velocidad.y < 0)
            {
                velocidad.y = -2f;
            }

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direccion = new Vector3(horizontal, 0f, vertical).normalized; //Normalized es para que al moverse en diagonal no vaya m�s r�pido
            animator.SetFloat(variableMovimiento, (Mathf.Abs(vertical) + Mathf.Abs(horizontal)));

            if (direccion.magnitude >= 0.1f)
            {
                float anguloARotar = Mathf.Atan2(direccion.x, direccion.z) * Mathf.Rad2Deg + camara.eulerAngles.y;
                float angulo = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloARotar, ref velocidadRotacionSuave, rotacionSuave);
                transform.rotation = Quaternion.Euler(0f, angulo, 0f);

                Vector3 direccionDelMovimiento = Quaternion.Euler(0f, anguloARotar, 0f) * Vector3.forward;
                if (Input.GetButton("Fire3"))
                {
                    controlador.Move(direccionDelMovimiento.normalized * (velocidadDeMovimiento *2) * Time.deltaTime);
                }
                controlador.Move(direccionDelMovimiento.normalized * velocidadDeMovimiento * Time.deltaTime);
            }

            if (Input.GetButtonDown("Jump") && estaEnElSuelo)
            {
                velocidad.y = Mathf.Sqrt(alturaDelSalto * -2f * gravedad);
            }

            


            velocidad.y += gravedad * Time.deltaTime;
            controlador.Move(velocidad * Time.deltaTime);

            animator.SetBool(variableSuelo, controlador.isGrounded);
        }
    }
}