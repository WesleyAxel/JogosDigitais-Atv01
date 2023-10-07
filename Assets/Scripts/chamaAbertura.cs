using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chamaAbertura : MonoBehaviour
{
    public void AbrirGame() {
        SceneManager.LoadScene("inicioPuzzle");
    }

    public void AbrirCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }

    public void sairJogo()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
