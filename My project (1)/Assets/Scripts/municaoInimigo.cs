using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municaoInimigo : MonoBehaviour
{
   public  float speed;
   private player1 objPlayer;
    private int sentidoDirecao;
    



    void Start()
    {
        objPlayer = FindObjectOfType(typeof(player1)) as player1;
    }

    // Update is called once per frame
    void Update()
    {
       
       

        
        if (objPlayer.inimigo.transform.position.x > objPlayer.player.transform.position.x)
        {
            sentidoDirecao = -1;
        }
        else if (objPlayer.inimigo.transform.position.x < objPlayer.player.transform.position.x)
        {
            sentidoDirecao = 1;
        }

        if (transform.position.x >= objPlayer.player.transform.position.x && objPlayer.inimigo.transform.position.x < objPlayer.player.transform.position.x)
        {
            Destroy(gameObject);
        }

        if (transform.position.x <= objPlayer.player.transform.position.x && objPlayer.inimigo.transform.position.x > objPlayer.player.transform.position.x)
        {
            Destroy(gameObject);
        }

        if (objPlayer.inimigo.transform.position.y > objPlayer.player.transform.position.y)
        {
            sentidoDirecao = -1;
        }








        transform.Translate(new Vector2(1f, 0f) * Time.deltaTime *  sentidoDirecao *  speed);
      








    }


}
