using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MovimentoPlayer : MonoBehaviour {
    [SerializeField] float moveSpeed;
    Vector2 moveInput;
    public Text municao;
    public int quantMunicao;
    public Text por;
    public int quantPor;
    public float vidaInicial;
    public float vidaAtual;
    public float percVida;
    public Image barraVida;
    public Animator Anim;
    public bool Run;
    public GameObject carta1;
    public GameObject carta2;
    public GameObject carta3;
    public GameObject carta4;
    public GameObject painelInfo;
    public GameObject Carta;
    public GameObject seringa;
    public GameObject[] bauAberto;
    public GameObject[] bauFechado;
    public GameObject[] cartaDiretor;
    private bool pausa;
    
    public GameObject cartaD1;
    public GameObject cartaD2;
    private float raioX, raioY;
    public LayerMask layerInteracao;
    public GameObject informacaoInteracao;
    private Rigidbody2D rbPlayer;
    public float distancia;
    public GameObject[] iconeCarta;
    public bool[] isCartas;
    public bool[] isCartasDiretor;
    public int CartasLidas;
    public GameObject inimigos;
    public GameObject cameraAnimacao;

    
    public GameObject baufinalAberto;

    private bool controlAnimacaoCamera;
    public float tempo;
    public bool isTempo;

    public bool verificarBotao;

    public GameObject porcaoMunicao;

    public int quantMinicaoBau;
    public int quantPorcaoBau;

    private MovimentoInimigo moveInimigo;

    private municaoInimigo muniInimigo;

    public GameObject cameraMapa;

    private bool isCameraMapa;

    void Start() {
        vidaAtual = vidaInicial;
        Anim = GetComponent<Animator>();
        Carta.SetActive(false);
        seringa.SetActive(false);
        bauAberto[0].SetActive(false);
        bauFechado[0].SetActive(true);
        bauAberto[1].SetActive(false);
        bauFechado[1].SetActive(true);
        bauAberto[3].SetActive(false);
        bauFechado[3].SetActive(true);
        bauAberto[4].SetActive(false);
        bauFechado[4].SetActive(true);
        pausa = false;
        rbPlayer = GetComponent<Rigidbody2D>();

        seringa.SetActive(false);
        moveInimigo = FindObjectOfType(typeof(MovimentoInimigo)) as MovimentoInimigo;

        muniInimigo = FindObjectOfType(typeof(municaoInimigo)) as municaoInimigo;

        

        moveInimigo.playerTransform  = this.transform;

        cameraMapa.SetActive(false);

    }
    void Update() {
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        //transform.Translate(moveInput * Time.deltaTime * moveSpeed);
        rbPlayer.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        if (moveInput.x != 0 || moveInput.y != 0) {
            raioX = moveInput.x;
            raioY = moveInput.y;
        }
        if (moveInput.x != 0 || moveInput.y != 0) {
            Run = true;
        }
        else {
            Run = false;
        }
        if (moveInput.y > 0) {
            Anim.SetLayerWeight(1, 1);
            Anim.SetLayerWeight(2, 0);
            Anim.SetLayerWeight(3, 0);
        }
        if (moveInput.y < 0) {
            Anim.SetLayerWeight(1, 0);
            Anim.SetLayerWeight(2, 0);
            Anim.SetLayerWeight(3, 0);
        }
        if (moveInput.x > 0) {
            Anim.SetLayerWeight(1, 0);
            Anim.SetLayerWeight(2, 1);
            Anim.SetLayerWeight(3, 0);
        }
        if (moveInput.x < 0) {
            Anim.SetLayerWeight(1, 0);
            Anim.SetLayerWeight(2, 0);
            Anim.SetLayerWeight(3, 1);
        }
        if (vidaAtual <= 0) {
            SceneManager.LoadScene("GameOver");
        }
        Anim.SetBool("Run", Run);


        if (quantMunicao <= 0) {
            quantMunicao = 0;
            seringa.SetActive(false);
           

        }
        else {
            seringa.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.M) && isCameraMapa == false) {
            cameraMapa.SetActive(true);
            isCameraMapa = true;
        }
        else if (Input.GetKeyDown(KeyCode.M) && isCameraMapa == true){
            cameraMapa.SetActive(false);
            isCameraMapa = false;
        }

        if (Input.GetKeyDown(KeyCode.P) && pausa == false) {
            print("pausa");
            Time.timeScale = 0;
            pausa = true;

        }
        else if (Input.GetKeyDown(KeyCode.P) && pausa == true) {
            Time.timeScale = 1;
            pausa = false;
        }

        if(isTempo == true) {
            tempo += Time.deltaTime;
        }

       
        if (CartasLidas == 9 && controlAnimacaoCamera == false) {

            print("missão finalizada");
            cameraAnimacao.SetActive(true);
            baufinalAberto.SetActive(true);
            porcaoMunicao.SetActive(true);
            controlAnimacaoCamera = true;
            isTempo = true;
         
        }
        else {
            //cameraAnimacao.SetActive(false);
        }
        percentualVida();



        if (CartasLidas == 9 && Input.GetKeyDown(KeyCode.Q) && verificarBotao == false) {
            cameraAnimacao.SetActive(true);
            verificarBotao = true;


        }else 
        if(CartasLidas == 9 && Input.GetKeyDown(KeyCode.Q) && verificarBotao == true) {
            cameraAnimacao.SetActive(false);
            verificarBotao = false;
        }

        if(quantPor > 0) {
            if (Input.GetKeyDown(KeyCode.LeftShift) && percVida <1) {
                vidaAtual = vidaInicial;
                quantPor -= 1;
                por.text = quantPor.ToString();
                percVida = vidaAtual / vidaInicial;
                barraVida.fillAmount = percVida;
            }
        }
        else {
            quantPor = 0;
        }
            
           


    }

    public void fecharPainelInformacao() {
        cameraAnimacao.SetActive(false);
    }
   
    private void FixedUpdate() {
        RayCastPlayer();
    }
    private void RayCastPlayer() {
        Debug.DrawRay(transform.position, new Vector2(raioX, raioY) * 0.2f, Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector2(raioX, raioY), 0.3f, layerInteracao);
        if (hit == true) {
            distancia = hit.distance;
            informacaoInteracao.SetActive(true);
            if (hit.transform.gameObject.tag == "cartas" && Input.GetKey(KeyCode.R)) {

                isCartas[0] = true;
                Carta.SetActive(true);
                carta1.SetActive(true);
                carta2.SetActive(false);
                carta3.SetActive(false);
                carta4.SetActive(false);
                Time.timeScale = 0;
               
                Destroy(hit.transform.gameObject);

            }
            if (hit.transform.gameObject.tag == "Carta2" && Input.GetKey(KeyCode.R)) {

                isCartas[1] = true;
               
                Carta.SetActive(true);
                carta1.SetActive(false);
                carta2.SetActive(true);
                carta3.SetActive(false);
                carta4.SetActive(false);
                Time.timeScale = 0;
                Destroy(hit.transform.gameObject);
            }
            if (hit.transform.gameObject.tag == "Carta3" && Input.GetKey(KeyCode.R)) {

              
                isCartas[2] = true;
                Carta.SetActive(true);
                carta1.SetActive(false);
                carta2.SetActive(false);
                carta3.SetActive(true);
                carta4.SetActive(false);
                Destroy(hit.transform.gameObject);
                Time.timeScale = 0;
            }
            if (hit.transform.gameObject.tag == "Carta4" && Input.GetKey(KeyCode.R)) {

              
                Carta.SetActive(true);
                isCartas[3] = true;
                carta1.SetActive(false);
                carta2.SetActive(false);
                carta3.SetActive(false);
                carta4.SetActive(true);
                Destroy(hit.transform.gameObject);
                Time.timeScale = 0;
            }
            if (hit.transform.gameObject.tag == "Diretor1" && Input.GetKey(KeyCode.R)) {

                isCartasDiretor[0] = true;
               
                cartaDiretor[0].SetActive(true);
                cartaDiretor[1].SetActive(true);
                cartaDiretor[2].SetActive(false);
                cartaDiretor[3].SetActive(false);
                cartaDiretor[4].SetActive(false);
                cartaDiretor[5].SetActive(false);
                Destroy(hit.transform.gameObject);
                Time.timeScale = 0;
            }
            if (hit.transform.gameObject.tag == "DIretor2" && Input.GetKey(KeyCode.R))
                {

                isCartasDiretor[1] = true;
              
                cartaDiretor[0].SetActive(true);
                cartaDiretor[1].SetActive(false);
                cartaDiretor[2].SetActive(true);
                cartaDiretor[3].SetActive(false);
                cartaDiretor[4].SetActive(false);
                cartaDiretor[5].SetActive(false);
                Destroy(hit.transform.gameObject);
                Time.timeScale = 0;
            }
            if (hit.transform.gameObject.tag == "Diretor3" && Input.GetKey(KeyCode.R)) {
                isCartasDiretor[2] = true;
                
                cartaDiretor[0].SetActive(true);
                cartaDiretor[1].SetActive(false);
                cartaDiretor[2].SetActive(false);
                cartaDiretor[3].SetActive(true);
                cartaDiretor[4].SetActive(false);
                cartaDiretor[5].SetActive(false);
                Destroy(hit.transform.gameObject);
                Time.timeScale = 0;
            }
            if (hit.transform.gameObject.tag == "Diretor4" && Input.GetKey(KeyCode.R)) {
                isCartasDiretor[3] = true;
                
                cartaDiretor[0].SetActive(true);
                cartaDiretor[1].SetActive(false);
                cartaDiretor[2].SetActive(false);
                cartaDiretor[3].SetActive(false);
                cartaDiretor[4].SetActive(true);
                cartaDiretor[5].SetActive(false);
                Destroy(hit.transform.gameObject);
                Time.timeScale = 0;
            }
            if (hit.transform.gameObject.tag == "Diretor5" && Input.GetKey(KeyCode.R)) {
                isCartasDiretor[4] = true;
               
                cartaDiretor[0].SetActive(true);
                cartaDiretor[1].SetActive(false);
                cartaDiretor[2].SetActive(false);
                cartaDiretor[3].SetActive(false);
                cartaDiretor[4].SetActive(false);
                cartaDiretor[5].SetActive(true);
                Destroy(hit.transform.gameObject);
                Time.timeScale = 0;
            }
            if (hit.transform.gameObject.tag == "Bau" && Input.GetKey(KeyCode.R)) {
               
                bauAberto[0].SetActive(true);
                bauFechado[0].SetActive(false);
                Destroy(hit.transform.gameObject);
                StartCoroutine(iconeCarta1());
            }
            if (hit.transform.gameObject.tag == "Bau1" && Input.GetKey(KeyCode.R)) {
               
                bauAberto[1].SetActive(true);
                bauFechado[1].SetActive(false);
                Destroy(hit.transform.gameObject);
                StartCoroutine(iconeCarta2());
            }
            if (hit.transform.gameObject.tag == "Bau2" && Input.GetKey(KeyCode.R)) {
                
                bauAberto[2].SetActive(true);
                bauFechado[2].SetActive(false);
                Destroy(hit.transform.gameObject);
                StartCoroutine(iconeCarta3());
            }
            if (hit.transform.gameObject.tag == "Bau3" && Input.GetKey(KeyCode.R)) {
                
                bauAberto[3].SetActive(true);
                bauFechado[3].SetActive(false);
                Destroy(hit.transform.gameObject);
                StartCoroutine(iconeCarta4());

            }
            if (hit.transform.gameObject.tag == "Bau4" && Input.GetKey(KeyCode.R)) {
               
                bauAberto[4].SetActive(true);
                bauFechado[4].SetActive(false);
                Destroy(hit.transform.gameObject);
                StartCoroutine(iconeCarta5());
            }

            if (hit.transform.gameObject.tag == "Suprimentos" && Input.GetKey(KeyCode.R)) {

                quantMunicao = quantMinicaoBau;

                quantPor = quantPorcaoBau;
                municao.text = quantMunicao.ToString();
                por.text = quantPor.ToString();
                porcaoMunicao.SetActive(false);

                inimigos.SetActive(true);
            }
        }
        else {
            informacaoInteracao.SetActive(false);
        }
       
    }
    public void percentualVida() {
        percVida = vidaAtual / vidaInicial;
        barraVida.fillAmount = percVida;//diminui a barra de vida
    }
    IEnumerator iconeCarta1() {
        yield return new WaitForSeconds(0.5f);
        iconeCarta[0].SetActive(true);
    }
    IEnumerator iconeCarta2() {
        yield return new WaitForSeconds(0.5f);
        iconeCarta[1].SetActive(true);
    }
    IEnumerator iconeCarta3() {
        yield return new WaitForSeconds(0.5f);
        iconeCarta[2].SetActive(true);
    }
    IEnumerator iconeCarta4() {
        yield return new WaitForSeconds(0.5f);
        iconeCarta[3].SetActive(true);
    }
    IEnumerator iconeCarta5() {
        yield return new WaitForSeconds(0.5f);
        iconeCarta[4].SetActive(true);
    }
    private void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "inimigo") {
            vidaAtual -= 0.2f;

            if (vidaAtual == 0) {
                print("Fim de jogo");

            }
        }


    }
    private void OnTriggerEnter2D(Collider2D col) {
        /*if (col.gameObject.tag == "municao") {
            quantMunicao += 1;
            municao.text = quantMunicao.ToString();
            Destroy(col.gameObject);
        }*/

        if (col.gameObject.tag == "municaoInimigo") {
            vidaAtual -= 2;
            percVida = vidaAtual / vidaInicial;
            barraVida.fillAmount = percVida;

            Destroy(col.gameObject);
        }
        /*if (col.gameObject.tag == "pocao") {
            Destroy(col.gameObject);
            quantPor += 1;
            por.text = quantPor.ToString();
        }*/
    }

}




