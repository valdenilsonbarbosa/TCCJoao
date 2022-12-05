using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private bool audioOn = true;
    private Button controleSom;
    public GameObject buttonOff;
    public GameObject ButtonOn;

    private void Start()
    {
        controleSom = GetComponent<Button>();
        buttonOff.SetActive(false);
        ButtonOn.SetActive(true);
    }

    public void buttonOnn()
    {
        buttonOff.SetActive(true);
        ButtonOn.SetActive(false);


    }

    public void buttonOfff()
    {
        ButtonOn.SetActive(true);
        buttonOff.SetActive(false);
    }

    public void  VolumeGame()
    {
        audioOn = !audioOn;
        if(audioOn==true)
        {
            AudioListener.volume = 1;
        }
        else
        {
            AudioListener.volume = 0;

        }
    }

}

