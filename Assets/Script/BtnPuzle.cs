using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPuzle : MonoBehaviour
{
    public GameObject BtnPista;
    public GameObject BtnResponder;
    public GameObject BtnReiniciar;
    public GameObject Pistas;
    public GameObject PanelCorrecta;
    public GameObject PanelIncorrecta;
    public GameObject FadeFin;
    
    private Animator transitionAnimator;
    Solucion Solucion;
    public string PuzleActual;
    public string escena;

    public void Start()
    {
        Solucion = FindObjectOfType<Solucion>();
        transitionAnimator = FadeFin.GetComponent<Animator>();
    }

    public void Pista()
    {
        Pistas.SetActive(true);
    }
    
    public void Volver()
    {
        Pistas.SetActive(false);
    }

    public void Responder()
    {
        string Revisado = Solucion.Revisado(PuzleActual);
        if (Revisado == "Correcto")
        {
            BtnPista.SetActive(false);
            BtnResponder.SetActive(false);
            PanelCorrecta.SetActive(true);
            PanelIncorrecta.SetActive(false);
        }
        else if (Revisado == "Incorrecto")
        {
            BtnPista.SetActive(false);
            BtnResponder.SetActive(false);
            PanelCorrecta.SetActive(false);
            PanelIncorrecta.SetActive(true);
        }
        else
        {
            Debug.Log("Selecciona una respuesta");
        }
    }
    public void Reiniciar()
    {
        BtnPista.SetActive(true);
        BtnResponder.SetActive(true);
        PanelCorrecta.SetActive(false);
        PanelIncorrecta.SetActive(false);
        Solucion.Reinicio(PuzleActual);
    }

    public void Continuar()
    {
        FadeFin.SetActive(true);
        StartCoroutine(SceneLoad());
    }

    public IEnumerator SceneLoad()
    {
        transitionAnimator.SetTrigger("Empezar");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(escena);
    }
}
