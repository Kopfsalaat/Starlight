using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ActivaPuzle : MonoBehaviour
{
    public string nPuzle;
    public string escena;
    public GameObject Fade;
    public TextMeshProUGUI Titulo;
    private Chat chat;
    private Animator animator;
    private Animator fadeAnimator;
    private bool haveToChangeScene = false;
    
    void Start()
    {
        chat = GetComponent<Chat>();
        animator = GetComponent<Animator>();
        fadeAnimator = Fade.GetComponent<Animator>();
    }

    private void Update()
    {
        if(haveToChangeScene)
        {
            if(!chat.GetIsDialogueActive())
            {
                LoadNextScene();
            }
        }

    }

     private void OnTriggerEnter2D(Collider2D collision)
     {
            if(collision.tag == "Player")
            {
                haveToChangeScene = true;
                //GameManager.instance.lastPosition = collision.transform.position;
                if(animator != null) animator.SetBool("playerInRange", true);
            }
     }

    public void LoadNextScene()
    {
        Titulo.text = nPuzle;
        StartCoroutine(SceneLoad());
    }

    public IEnumerator SceneLoad()
    {
        Fade.SetActive(true);
        if(fadeAnimator != null) fadeAnimator.SetTrigger("StartTransition");
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
