using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Solucion : MonoBehaviour
{
    Puzle_1 Puzle1;
    public Button A;
    public Button B;
    public Button C;

    public void Start()
    {
        Puzle1 = FindObjectOfType<Puzle_1>();
    }


    public string Revisado (string Puzle)
    {
        Debug.Log("Revisando");
        string respuesta = Puzle1.Revision();
        A.interactable = false;
        B.interactable = false;
        C.interactable = false;
        return respuesta;
        /*switch(Puzle)
        {
            case "Puzle 01":
                respuesta = Puzle1.Revision();
                return respuesta;
        }*/
    }

    public void Reinicio()
    {
        A.interactable = true;
        B.interactable = true;
        C.interactable = true;
        Puzle1.Reinicia();
    }
}
