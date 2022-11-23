using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
[SerializeField] string mensajeAMostrar ="Hellow World";

    // Start is called before the first frame update
    void Start()
    {
        print(mensajeAMostrar);
    }

    // Update is called once per frame
    void Update()
    {
        print(mensajeAMostrar);
    }
}
