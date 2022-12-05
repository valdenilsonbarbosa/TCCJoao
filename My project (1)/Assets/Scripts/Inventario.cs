using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{
    private MovimentoPlayer movPlayer;
    private int id;
    public Button[] btnFilha;
    public Button[] btnDiretor;
    void Start()
    {
        movPlayer = FindObjectOfType(typeof(MovimentoPlayer)) as MovimentoPlayer;
        for(id =0; id<btnFilha.Length; id++) {
            btnFilha[id].interactable =false;
        }
        for (id = 0; id < btnDiretor.Length; id++) {
            btnDiretor[id].interactable = false;
        }
    }
    
    void Update()
    {
        if(movPlayer.isCartas[0] == true) {
            btnFilha[0].interactable = true;
        }
        if (movPlayer.isCartas[1] == true) {
            btnFilha[1].interactable = true;
        }
        if (movPlayer.isCartas[2] == true) {
            btnFilha[2].interactable = true;
        }
        if (movPlayer.isCartas[3] == true) {
            btnFilha[3].interactable = true;
        }
        if (movPlayer.isCartasDiretor[0] == true) {
            btnDiretor[0].interactable = true;
        }
        if (movPlayer.isCartasDiretor[1] == true) {
            btnDiretor[1].interactable = true;
        }
        if (movPlayer.isCartasDiretor[2] == true) {
            btnDiretor[2].interactable = true;
        }
        if (movPlayer.isCartasDiretor[3] == true) {
            btnDiretor[3].interactable = true;
        }
        if (movPlayer.isCartasDiretor[4] == true) {
            btnDiretor[4].interactable = true;
        }
    }
}
