using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Puzle_1 : MonoBehaviour
{
    public GameObject MarcaA;
    public GameObject MarcaB;
    public GameObject MarcaC;
    public string opcion;

    public void Opcion()
    {
        opcion = GetComponentInChildren<TMP_Text>().text;

        switch (opcion)
        {
            case "A":
                Debug.Log(opcion);
                MarcaA.SetActive(true);
                MarcaB.SetActive(false);
                MarcaC.SetActive(false);
                break;
            case "B":
                Debug.Log(opcion);
                MarcaA.SetActive(false);
                MarcaB.SetActive(true);
                MarcaC.SetActive(false);
                break;
            case "C":
                Debug.Log(opcion);
                MarcaA.SetActive(false);
                MarcaB.SetActive(false);
                MarcaC.SetActive(true);
                break;
        }
    }

    public string Revision()
    {
        if (MarcaA.activeSelf == true)
        {
            return "Correcto";
        }
        else
        {
            return "Incorrecto";
        }
    }

    public void Reinicia()
    {
        MarcaA.SetActive(false);
        MarcaB.SetActive(false);
        MarcaC.SetActive(false);
        opcion = null;
    }
}
