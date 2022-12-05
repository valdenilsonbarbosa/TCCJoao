using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Speed")]
    public float speed;


    [Header("Coletavel")]
    public Text scoreTxt;
    private float score;

    [Header("Barra Vida")]
    public Image Imagem;
    public float vida;
    public float vidaAtual;
    public float percentualVida; 



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        score=0;
        vidaAtual = vida;
    }

    // Update is called once per frame
    void Update()
    {                   
        float movimentoHorizontal = Input.GetAxisRaw("Horizontal");
        transform.Translate(new Vector3(1, 0, 0) * speed * movimentoHorizontal * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="moeda")
        {
            score += 1;
            Destroy(col.gameObject);
            scoreTxt.text = score.ToString();

        }


        if (col.gameObject.tag == "perdeVida")
        {

            vidaAtual -=2;

            print(vidaAtual);
            percentualVida = (float)( vida/vidaAtual);
        }


    }
}

