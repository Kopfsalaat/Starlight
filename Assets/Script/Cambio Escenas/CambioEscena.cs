using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public string escena;
    private Animator transitionAnimator;
    private GameObject Fade;

    void Start()
    {
        transitionAnimator = GetComponentInChildren<Animator>();
        Fade = Helpers.FindChildWithName(gameObject, "FadeEscena");
        StartCoroutine(DisableFade());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Fade.SetActive(true);
            collision.GetComponent<Animator>().SetFloat("Speed", 0f);
            collision.GetComponent<Player>().DisableMovement();
            LoadNextScene();
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(SceneLoad());
    }

    public IEnumerator SceneLoad()
    {
        transitionAnimator.SetTrigger("StartTransition");
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
