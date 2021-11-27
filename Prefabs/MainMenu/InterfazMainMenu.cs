using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfazMainMenu : MonoBehaviour
{

    public void buttonAbrirMainMenu()
    {
        transform.Find("ButtonActivarMenu").gameObject.SetActive(false);
        transform.Find("FrameMenu").gameObject.SetActive(true);
        transform.Find("Sonidos").Find("ClickBasic1").GetComponent<AudioSource>().Play();
    }
    public void buttonCerrarMainMenu()
    {
        transform.Find("ButtonActivarMenu").gameObject.SetActive(true);
        transform.Find("FrameMenu").gameObject.SetActive(false);
        transform.Find("Sonidos").Find("ClickCancelar").GetComponent<AudioSource>().Play();
    }
    public void buttonAbrirCrearPartida()
    {
        transform.Find("FrameMenu").Find("FrameCrearPartida").gameObject.SetActive(true);
        transform.Find("FrameMenu").Find("FrameInicio").gameObject.SetActive(false);
        transform.Find("Sonidos").Find("ClickBasic1").GetComponent<AudioSource>().Play();
    }
    public void buttonCerrarCrearPartida()
    {
        transform.Find("FrameMenu").Find("FrameCrearPartida").gameObject.SetActive(false);
        transform.Find("FrameMenu").Find("FrameInicio").gameObject.SetActive(true);
        transform.Find("Sonidos").Find("ClickCancelar").GetComponent<AudioSource>().Play();
    }

}
