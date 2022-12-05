using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour
{
    public GameObject carta1;
    public GameObject carta2;
    public GameObject carta3;
    public GameObject carta4;
    public GameObject carta5;
    public GameObject painelInfo;

    private bool PausaGame;

    void Start()
    {
        carta1.SetActive(false);
        carta2.SetActive(false);
        carta3.SetActive(false);
        carta4.SetActive(false);
        carta5.SetActive(false);

    }

    
    void Update()
    {
        if(PausaGame == true)
        {
           
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name=="carta1")
        {
            painelInfo.SetActive(true);
            carta1.SetActive(true);
            carta2.SetActive(false);
            carta3.SetActive(false);
            carta4.SetActive(false);
            carta5.SetActive(false);

            PausaGame = true;

        }

    }

   


}
