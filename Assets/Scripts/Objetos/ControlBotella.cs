using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBotella : MonoBehaviour
{
    public GameObject botella;
    bool rotar;
    float altura;
    float velocidad = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        botella.gameObject.GetComponent<Transform>();
        rotar = false;
        altura = 800.0f;
        StartCoroutine(Comportamiento());
    }

    // Update is called once per frame
    void Update()
    {
        if (rotar)
        {
            botella.transform.Rotate(0, velocidad * Time.deltaTime,0);
        }
    }

    IEnumerator Comportamiento()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        botella.transform.Translate(Vector3.up * altura * Time.deltaTime);
        yield return new WaitForSecondsRealtime(0.5f);
        rotar = true;
        yield return null;

    }
}
