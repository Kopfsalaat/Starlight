using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public GameObject PanelPausa;
    public GameObject PanelFade;
    public bool IsPaused;

    // Start is called before the first frame update
    void Start()
    {
        PanelPausa.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(IsPaused)
            {
                resumeGame();
            }
            else
            {
                pauseGame();
            }
        }
    }

    public void pauseGame()
    {
        PanelPausa.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
        PanelFade.SetActive(false);
    }

    public void resumeGame()
    {
        PanelPausa.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
        PanelFade.SetActive(true);
    }

    public void Salir()
    {
        Debug.Log("Saliendo...");
        Application.Quit();
    }
}
