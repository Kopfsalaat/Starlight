using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Solucion : MonoBehaviour
{
    Puzle_1 Puzle1;
    Puzle_2 Puzle2;
    public Button A;
    public Button B;
    public Button C;
    [HideInInspector] string respuesta;

    public void Start()
    {
        Puzle1 = FindObjectOfType<Puzle_1>();
        Puzle2 = FindObjectOfType<Puzle_2>();
    }


    public string Revisado (string Puzle)
    {  
        switch(Puzle)
        {
            case "Puzle 01":
                respuesta = Puzle1.Revision();
                A.interactable = false;
                B.interactable = false;
                C.interactable = false;
                break;
            case "Puzle 02":
                respuesta = Puzle2.Revision();
                break;
        }
        return respuesta;
    }

    public void Reinicio(string Puzle)
    {
        switch(Puzle)
        {
            case "Puzle 01":
                Puzle1.Reinicia();
                A.interactable = true;
                B.interactable = true;
                C.interactable = true;
                break;
            case "Puzle 02":
                Puzle2.Reinicia();
                break;
        }
    }
}
