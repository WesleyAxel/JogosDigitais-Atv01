using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textController : MonoBehaviour
{

    public void AtualizarTextoVitoria()
    {
        GameObject textoVitoriaObj = GameObject.FindGameObjectWithTag("textoVitoria");

        if (textoVitoriaObj != null)
        {
            Text textoVitoria = textoVitoriaObj.GetComponent<Text>();
            textoVitoria.text = "Parabéns você venceu!";
        }
        else
        {
            Debug.Log("Texto de vitória não encontrado!");
        }
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
