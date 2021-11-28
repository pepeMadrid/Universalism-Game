using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SettingsLocal;
using UnityEngine.UI;
using TMPro;
using System;

public class InterfazMainMenu : MonoBehaviour
{
    private void Awake()
    {
        settingsActivar();
    }

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
        transform.Find("FrameMenu").Find("FrameCrearPartida").Find("LabelDate").GetComponent<TextMeshProUGUI>().SetText(DateTime.Now+"");
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
    public void buttonAbrirSettings()
    {
        settingsToInterfaz();
        transform.Find("FrameMenu").Find("FrameSettings").gameObject.SetActive(true);
        transform.Find("FrameMenu").Find("FrameInicio").gameObject.SetActive(false);
        transform.Find("Sonidos").Find("ClickBasic1").GetComponent<AudioSource>().Play();
    }
    public void buttonCerrarSettings()
    {
        transform.Find("FrameMenu").Find("FrameSettings").gameObject.SetActive(false);
        transform.Find("FrameMenu").Find("FrameInicio").gameObject.SetActive(true);
        transform.Find("Sonidos").Find("ClickCancelar").GetComponent<AudioSource>().Play();
    }
    public void buttonAceptarConfiguracion()
    {
        guardarSettings();
        settingsActivar();
        transform.Find("FrameMenu").Find("FrameSettings").gameObject.SetActive(false);
        transform.Find("FrameMenu").Find("FrameInicio").gameObject.SetActive(true);
        transform.Find("Sonidos").Find("ClickAceptar").GetComponent<AudioSource>().Play();
    }

    public void buttonAceptarError()
    {
        transform.Find("FrameMenu").Find("InfoPanel").gameObject.SetActive(false);
        transform.Find("FrameMenu").Find("FrameInicio").gameObject.SetActive(true);
        transform.Find("Sonidos").Find("ClickCancelar").GetComponent<AudioSource>().Play();
    }

    public void radioEsp()
    {
        transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaEsp").Find("RadioActivado").gameObject.SetActive(true);
        transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaIngles").Find("RadioActivado").gameObject.SetActive(false);
    }
    public void radioIngles()
    {
        transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaIngles").Find("RadioActivado").gameObject.SetActive(true);
        transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaEsp").Find("RadioActivado").gameObject.SetActive(false);
    }
    private void settingsToInterfaz()
    {
        //parse de objeto guardado en archivo y mostrarlo en la interfaz
        Settings settingsGuardados = transform.GetComponent<SettingsLocal>().leerSettings();
        switch (settingsGuardados.getIdioma())
        {
            case 0://ingles activado
                transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaEsp").Find("RadioActivado").gameObject.SetActive(false);
                transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaIngles").Find("RadioActivado").gameObject.SetActive(true);
            break;
            case 1://español activado
                transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaIngles").Find("RadioActivado").gameObject.SetActive(false);
                transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaEsp").Find("RadioActivado").gameObject.SetActive(true);
            break;
        }

        transform.Find("FrameMenu").Find("FrameSettings").Find("SliderMusica").GetComponent<Slider>().value = settingsGuardados.getVolumenMusica();
        transform.Find("FrameMenu").Find("FrameSettings").Find("SliderSonidos").GetComponent<Slider>().value = settingsGuardados.getVolumenSonidos();
    }
    private void guardarSettings()
    {
        Settings configuracionModificada = transform.GetComponent<SettingsLocal>().leerSettings();
        if (transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaIngles").Find("RadioActivado").gameObject.activeInHierarchy)
            configuracionModificada.setIdioma(0);
        else if (transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaEsp").Find("RadioActivado").gameObject.activeInHierarchy)
            configuracionModificada.setIdioma(1);

        configuracionModificada.setVolumenMusica(transform.Find("FrameMenu").Find("FrameSettings").Find("SliderMusica").GetComponent<Slider>().value);
        configuracionModificada.setVolumenSonidos(transform.Find("FrameMenu").Find("FrameSettings").Find("SliderSonidos").GetComponent<Slider>().value);
        //...... 
        transform.GetComponent<SettingsLocal>().guardarSettings(configuracionModificada);
    }

    private void settingsActivar()
    {//Hacer efectivo la configuración
        Settings settingsGuardados = transform.GetComponent<SettingsLocal>().leerSettings();

        for (int x = 0; x < transform.Find("BSO").childCount; x++)
            transform.Find("BSO").GetChild(x).GetComponent<AudioSource>().volume = settingsGuardados.getVolumenMusica();

        for (int x = 0; x < transform.Find("Sonidos").childCount; x++)
            transform.Find("Sonidos").GetChild(x).GetComponent<AudioSource>().volume = settingsGuardados.getVolumenSonidos();
    }

    public void crearPartida()
    {
        int codigoError;
        if (!String.IsNullOrWhiteSpace(transform.Find("FrameMenu").Find("FrameCrearPartida").Find("NombreText").Find("TextArea").Find("Text").GetComponent<TextMeshProUGUI>().text))
        {
            codigoError = transform.GetComponent<SaveLoadLocal>().crearArchivo(transform.Find("FrameMenu").Find("FrameCrearPartida").Find("NombreText").Find("TextArea").Find("Text").GetComponent<TextMeshProUGUI>().text, DateTime.Now + "");
            if (codigoError == 0)
            {
                //cargamos escena inicial
            }
            else
            {
                transform.Find("FrameMenu").Find("InfoPanel").gameObject.SetActive(true);
                transform.Find("FrameMenu").Find("FrameCrearPartida").gameObject.SetActive(false);
                transform.Find("Sonidos").Find("ErrorSound").GetComponent<AudioSource>().Play();
                transform.Find("FrameMenu").Find("InfoPanel").Find("InfoText").GetComponent<TextMeshProUGUI>().text = transform.GetComponent<TraductorIdiomas>().busquedaPorID("ErrorNombreExiste");
            }
        }
    }



}
