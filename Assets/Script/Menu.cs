using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] public GameObject Fade;
    [SerializeField] public string escena;
    private Animator transitionAnimator;

    public void Start()
    {
        transitionAnimator = Fade.GetComponent<Animator>();
    }

    public void Jugar()
    {
        Fade.SetActive(true);
        StartCoroutine(SceneLoad());
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }

    public IEnumerator SceneLoad()
    {
        transitionAnimator.SetTrigger("Empezar");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(escena);
        StartCoroutine(DisableFade());
    }

    public IEnumerator DisableFade()
    {
        yield return new WaitForSeconds(1f);
        Fade.SetActive(false);
    }
}
