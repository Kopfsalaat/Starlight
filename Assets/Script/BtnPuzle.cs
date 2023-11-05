using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BtnPuzle : MonoBehaviour
{
    public GameObject BtnPista;
    public GameObject BtnResponder;
    public GameObject BtnReiniciar;
    public GameObject PanelPista;
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
        PanelPista.SetActive(true);
    }
    
    public void Volver()
    {
        PanelPista.SetActive(false);
    }

    public void Responder()
    {
        Debug.Log("vamoa revisar");
        string Revisado = Solucion.Revisado(PuzleActual);
        BtnPista.SetActive(false);
        BtnResponder.SetActive(false);
        if (Revisado == "Correcto")
        {
            PanelCorrecta.SetActive(true);
            PanelIncorrecta.SetActive(false);
        }
        else if (Revisado == "Incorrecto")
        {
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
        Solucion.Reinicio();
    }

    public void Continuar()
    {
        FadeFin.SetActive(true);
        StartCoroutine(SceneLoad());
    }

    public IEnumerator SceneLoad()
    {
        FadeFin.SetActive(true);
        transitionAnimator.SetTrigger("Empezar");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(escena);
    }
}
