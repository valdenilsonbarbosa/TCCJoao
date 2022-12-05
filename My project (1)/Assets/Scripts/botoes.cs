using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class botoes : MonoBehaviour
{
    public GameObject fecharCenas;
    public GameObject painelCarta;
    public GameObject painelCartaDiretor;
    

    private MovimentoPlayer move;

    private void Start() {
        move = FindObjectOfType(typeof(MovimentoPlayer)) as MovimentoPlayer;
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("CenaTD");

    }
    public void Comecar()
    {
        SceneManager.LoadScene("Instruções");
    }
    public void Instrucoes()
    {
        SceneManager.LoadScene("Instruções");
    }

    public void Sair()
    {
        Application.Quit();
    }

    public void fecharCarta()
    {
        fecharCenas.SetActive(false);
        painelCarta.SetActive(false);
        painelCartaDiretor.SetActive(false);
        Time.timeScale = 1;
        move.CartasLidas += 1;
    }

    public void fecharCarta1()
    {
        fecharCenas.SetActive(false);
        painelCarta.SetActive(false);
        painelCartaDiretor.SetActive(false);
        Time.timeScale = 1;
        move.CartasLidas += 1;
    }

    public void fecharCarta2()
    {
        fecharCenas.SetActive(false);
        painelCarta.SetActive(false);
        painelCartaDiretor.SetActive(false);
        Time.timeScale = 1;
        move.CartasLidas += 1;
    }

    public void fecharCarta3()
    {
        fecharCenas.SetActive(false);
        painelCarta.SetActive(false);
        painelCartaDiretor.SetActive(false);
        Time.timeScale = 1;
        move.CartasLidas += 1;
    }

    public void fecharCarta4()
    {
        fecharCenas.SetActive(false);
        painelCarta.SetActive(false);
        painelCartaDiretor.SetActive(false);
        Time.timeScale = 1;
        move.CartasLidas += 1;
    }

    public void fecharCartadiretor()
    {
        fecharCenas.SetActive(false);
        painelCartaDiretor.SetActive(false);
        Time.timeScale = 1;
        move.CartasLidas += 1;




    }

    public void Inventario()
    {
        SceneManager.LoadScene("Inventario");
    }

   

}
