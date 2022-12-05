using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoArma : MonoBehaviour
{
    SpriteRenderer sprite;
    public GameObject municao;
    public Transform SpawnMunicao;
    private MovimentoPlayer movimento;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        movimento = FindObjectOfType(typeof(MovimentoPlayer)) as MovimentoPlayer;
        
    }

    // Update is called once per frame
    void Update()
    {
        Aim();
        Shoot();
    }
  
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && movimento.quantMunicao != 0) 
        {
            Instantiate(municao, SpawnMunicao.position, transform.rotation);

            movimento.quantMunicao -= 1;

           movimento.municao.text = movimento.quantMunicao.ToString();
        }
    }



    void Aim()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

        Vector2 offset = new Vector2(mousePos.x - screenPoint.x, mousePos.y - screenPoint.y);

        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);

        sprite.flipY = (mousePos.x < screenPoint.x);
    }
}
