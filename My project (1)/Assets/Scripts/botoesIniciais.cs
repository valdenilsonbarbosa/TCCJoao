using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botoesIniciais : MonoBehaviour
{

    public void Iniciar()
    {
        SceneManager.LoadScene("Instruções");
    }

    public void sair()
    {
        Application.Quit();
    }
}
