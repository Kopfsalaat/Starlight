using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Pistas : MonoBehaviour
{
    public GameObject Panel;
    public Button P1;
    public Button P2;
    public Button P3;
    public Button Salir;
    public Button Volver;
    public Button pActiva;
    public TMP_Text TPistaActiva;
    public GameObject TPista1;
    public GameObject TPista2;
    public GameObject TPista3;

    public void Clue()
    {
        string botonPista = GetComponentInChildren<TMP_Text>().text;
        Panel.SetActive(true);
        P1.gameObject.SetActive(false);
        P2.gameObject.SetActive(false);
        P3.gameObject.SetActive(false);
        Salir.gameObject.SetActive(false);
        pActiva.gameObject.SetActive(true);
        Volver.gameObject.SetActive(true);
        TPistaActiva.text = botonPista;
        switch(botonPista)
        {
            case "Pista 1":
                TPista1.gameObject.SetActive(true);
                TPista2.gameObject.SetActive(false);
                TPista3.gameObject.SetActive(false);
                break;
            case "Pista 2":
                TPista1.gameObject.SetActive(false);
                TPista2.gameObject.SetActive(true);
                TPista3.gameObject.SetActive(false);
                break;
            case "Pista 3":
                TPista1.gameObject.SetActive(false);
                TPista2.gameObject.SetActive(false);
                TPista3.gameObject.SetActive(true);
                break;
        }
    }

    public void DesactivarPanel()
    {
        Panel.SetActive(false);
        P1.gameObject.SetActive(true);
        P2.gameObject.SetActive(true);
        P3.gameObject.SetActive(true);
        Salir.gameObject.SetActive(true);
        Volver.gameObject.SetActive(false);
        pActiva.gameObject.SetActive(false);
        TPista1.gameObject.SetActive(false);
        TPista2.gameObject.SetActive(false);
        TPista3.gameObject.SetActive(false);
    }

}
