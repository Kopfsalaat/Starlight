using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    private void OnMouseUp()
    {
        LoadScene("Puzle");
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("haceme click");
    }
}
