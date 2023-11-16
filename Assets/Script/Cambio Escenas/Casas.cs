using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Casas : MonoBehaviour
{
    [SerializeField] private GameObject actionMark;
    [SerializeField] private GameObject Fade;
    [SerializeField] public string escena;
    private GameObject player;
    private Animator transitionAnimator;
    private bool isPlayerInRange;

    void Start()
    {
        transitionAnimator = Fade.GetComponent<Animator>();
    }

    void Update()
    {
        if(isPlayerInRange)
        {
            if(Input.GetKeyDown("e"))
            {
                LoadNextScene();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            player = collision.gameObject;
            isPlayerInRange = true;
            if(actionMark != null)
            {
                actionMark.SetActive(true);
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            isPlayerInRange = false;
            if(actionMark != null)
            {
                actionMark.SetActive(false);
            }
        }
    }

    public void LoadNextScene()
    {
        StartCoroutine(SceneLoad());
    }

    public IEnumerator SceneLoad()
    {
        Fade.SetActive(true);
        if(transitionAnimator != null) transitionAnimator.SetTrigger("Empezar");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(escena);
    }
}
