using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botoesIniciais : MonoBehaviour
{

    public void Iniciar()
    {
        SceneManager.LoadScene("Instru��es");
    }

    public void sair()
    {
        Application.Quit();
    }
}
