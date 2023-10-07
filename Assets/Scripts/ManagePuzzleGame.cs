using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class ManagePuzzleGame : MonoBehaviour
{
    // Start is called before the first frame update
    public Image parte;
    public Image localMarcado;
    public Text textComponent;
    float lmLargura, lmAltura, timer, timer2;
    bool partesEmbaralhadas = false;
    bool vitoria = false;

    void criarLocaisMarcados()
    {
        lmLargura = 100; lmAltura = 100;
        float numLinhas = 5; float numColunas = 5;
        float linha, coluna;
        for (int i = 0; i < 25; i++) {
            Vector3 posicaoCentro = new Vector3();
            posicaoCentro = GameObject.Find("ladoDireito").transform.position;
            linha = i % 5;
            coluna = i / 5;
            Vector3 lmPosicao = new Vector3(posicaoCentro.x + lmLargura * (linha - numLinhas / 2),
                posicaoCentro.y - lmAltura * (coluna - numColunas / 2),
                posicaoCentro.z);
            Image lm = (Image)(Instantiate(localMarcado, lmPosicao, Quaternion.identity));
            lm.tag = "" + (i + 1);
            lm.name = "LM" + (i + 1);
            lm.transform.SetParent(GameObject.Find("Canvas").transform);
        
        }

    }

    public void criarPartes()
    {
        lmLargura = 100; lmAltura = 100;
        float numLinhas ,numColunas;
        numLinhas = numColunas = 5;
        float linha, coluna;
        for (int i = 0; i < 25; i++) {
            Vector3 posicaoCentro = new Vector3();
            posicaoCentro = GameObject.Find("ladoEsquerdo").transform.position;
            linha = i % 5;
            coluna = i / 5;
            Vector3 lmPosicao = new Vector3(posicaoCentro.x + lmLargura * (linha - numLinhas / 2),
                posicaoCentro.y - lmAltura * (coluna - numColunas / 2),
                posicaoCentro.z);
            Image lm = (Image)(Instantiate(parte, lmPosicao, Quaternion.identity));
            lm.tag = "" + (i + 1);
            lm.name = "Parte" + (i + 1);
            lm.transform.SetParent(GameObject.Find("Canvas").transform);
            Sprite[] todasSprites = Resources.LoadAll<Sprite>("janta");
            Sprite s1 = todasSprites[i];
            lm.GetComponent<Image>().sprite = s1;
        }

    }

    void embaralhaPartes()
    {
        int[] novoArray = new int[25];
        for (int i = 0; i < 25; i++)
            novoArray[i] = i;
        int tmp;
        for (int t = 0; t < 25; t++) {
            tmp = novoArray[t];
            int r = Random.Range(t, 10);
            novoArray[t] = novoArray[r];
            novoArray[r] = tmp;
        }
        float linha, coluna, numLinhas, numColunas;
        numLinhas = numColunas = 5;
        for (int i = 0; i < 25; i++) {
            linha = (novoArray[i]) % 5;
            coluna = (novoArray[i]) / 5;
            Vector3 posicaoCentro = new Vector3();
            posicaoCentro = GameObject.Find("ladoEsquerdo").transform.position;
            var g = GameObject.Find("Parte" + (i + 1));
            Vector3 novaPosicao = new Vector3(posicaoCentro.x + lmLargura * (linha - numLinhas / 2),
                posicaoCentro.y - lmAltura * (coluna - numColunas / 2),
                posicaoCentro.z);
            g.transform.position = novaPosicao;
            g.GetComponent<DragAndDrop>().posicaoInicialPartes();
        }
    }

    void falaInicial() {
        GameObject.Find("totemInicio").GetComponent<tocadorInicio>().playInicio();
    }

    void falaPlay()
    {
        GameObject.Find("totemPlay").GetComponent<tocadorPlay>().playPlay();
    }

    void somVitoria()
    {
        GameObject.Find("totemWin").GetComponent<tocadorWin>().playWin();
    }

    private bool VerificarPosicaoPartes()
    {
        for (int i = 1; i <= 25; i++)
        {
            string nomeParte = "Parte" + i;
            string nomeLM = "LM" + i;

            GameObject parte = GameObject.Find(nomeParte);
            GameObject LM = GameObject.Find(nomeLM);

            if (parte != null && LM != null)
            {
                Vector3 posicaoParte = parte.transform.position;
                Vector3 posicaoLM = LM.transform.position;

                if (posicaoParte != posicaoLM)
                {
                    return false; 
                }
            }
            else
            {
                return false; 
            }
        }

        return true; 
    }

    public void AtualizarTexto()
    {
        GameObject textoVitoriaObj = GameObject.FindGameObjectWithTag("textoVitoria");

        if (textoVitoriaObj != null)
        {
            TextMeshProUGUI textMeshProUGUI = textoVitoriaObj.GetComponent<TextMeshProUGUI>();
            if (textMeshProUGUI != null)
            {
                vitoria = true;
                somVitoria();
                textMeshProUGUI.text = "Parabéns você Venceu!";
            }
            else
            {
                Debug.Log("Componente TextMeshProUGUI não encontrado no objeto com a tag 'textoVitoria'");
            }
        }
        else
        {
            Debug.Log("Objeto com a tag 'textoVitoria' não encontrado!");
        }
    }

    void Start()
    {
        criarLocaisMarcados();
        criarPartes();
        falaInicial();
        //embaralhaPartes();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 4 && !partesEmbaralhadas) {
            embaralhaPartes();
            falaPlay();
            partesEmbaralhadas = true;
        }

        if (VerificarPosicaoPartes() == true && partesEmbaralhadas == true && vitoria == false)
        {
            AtualizarTexto();
        }
    }

    public void sairMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
