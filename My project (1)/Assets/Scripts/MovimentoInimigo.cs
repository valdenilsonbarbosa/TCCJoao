using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoInimigo : MonoBehaviour
{
    public float speed;
    GameObject player;
    public bool isAlive = true;
    public float distance;
    public GameObject municao;
    public Transform SpawnMunicao;

  //  public Transform player;

    public Transform playerTransform;


    void Start()
    {
       // player = GameObject.FindGameObjectWithTag("Player");

        StartCoroutine(atacar());

    }

    // Update is called once per frame
    void Update()
    {


        Ataque();

    }
    
    
    public void Ataque()
    {
        distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance < 1f)
        {
            speed = 0.2f;
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, speed * Time.deltaTime);

        }
        else
        {
            speed = 0;
        }
  

    }



    IEnumerator atacar()
    {

  
        yield return new WaitForSeconds(2f);



        distance = Vector2.Distance(transform.position, playerTransform.position);

        if (distance < 2f)
        {
            Instantiate(municao, SpawnMunicao.position, transform.rotation);

        }
        else
        {

        }


        StartCoroutine(atacar());



    }



}
