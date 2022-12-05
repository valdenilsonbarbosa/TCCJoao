using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotoesInventario : MonoBehaviour
{
    private MovimentoPlayer movePlayer;

    public GameObject[] cartaFilha;

    public GameObject InventarioPainel;
    public GameObject[] cartaDiretor;

    

    private void Start() {

        movePlayer = FindObjectOfType(typeof(MovimentoPlayer)) as MovimentoPlayer;
    }
    public void Inventario() {
        InventarioPainel.SetActive(true);
    }
    public void FecharInventario() {
        InventarioPainel.SetActive(false);
    }
    public void SairInventario() {

        SceneManager.LoadScene("CenaTD");

    }
    public void cartaFilha1() {
        cartaFilha[0].SetActive(true);
        cartaFilha[1].SetActive(true);
    }
    public void cartaFilha2() {
        cartaFilha[0].SetActive(true);
        cartaFilha[2].SetActive(true);
    }
    public void cartaFilha3() {
        cartaFilha[0].SetActive(true);
        cartaFilha[3].SetActive(true);
        
    }
    public void cartaFilha4() {
        cartaFilha[0].SetActive(true);
        cartaFilha[4].SetActive(true);
        
    }
    public void cartaFecharFilha1() {
        cartaFilha[0].SetActive(false);
        cartaFilha[1].SetActive(false);
       
    }
    public void cartaFecharFilha2() {
        cartaFilha[0].SetActive(false);
        cartaFilha[2].SetActive(false);
      
    }
    public void cartaFecharFilha3() {
        cartaFilha[0].SetActive(false);
        cartaFilha[3].SetActive(false);
        
    }
    public void cartaFecharFilha4() {
        cartaFilha[0].SetActive(false);
        cartaFilha[4].SetActive(false);
        
    }
    public void cartaDiretor1() {
        cartaDiretor[0].SetActive(true);
        cartaDiretor[1].SetActive(true);
        
    }
    public void cartaDiretor2() {
        cartaDiretor[0].SetActive(true);
        cartaDiretor[2].SetActive(true);
     
    }
    public void cartaDiretor3() {
        cartaDiretor[0].SetActive(true);
        cartaDiretor[3].SetActive(true);
        
    }
    public void cartaDiretor4() {
        cartaDiretor[0].SetActive(true);
        cartaDiretor[4].SetActive(true);
    }
    public void cartaDiretor5() {
        cartaDiretor[0].SetActive(true);
        cartaDiretor[5].SetActive(true);
    }
    public void cartaFecharDiretor1() {
        cartaDiretor[0].SetActive(false);
        cartaDiretor[1].SetActive(false);
        
    }
    public void cartaFecharDiretor2() {
        cartaDiretor[0].SetActive(false);
        cartaDiretor[2].SetActive(false);
        
    }
    public void cartaFecharDiretor3() {
        cartaDiretor[0].SetActive(false);
        cartaDiretor[3].SetActive(false);
        
    }
    public void cartaFecharDiretor4() {
        cartaDiretor[0].SetActive(false);
        cartaDiretor[4].SetActive(false);
      
    }
    public void cartaFecharDiretor5() {
        cartaDiretor[0].SetActive(false);
        cartaDiretor[5].SetActive(false);
      
    }
}
