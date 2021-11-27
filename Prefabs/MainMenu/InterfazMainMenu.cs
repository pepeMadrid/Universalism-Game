using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SettingsLocal;

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
        transform.Find("FrameMenu").Find("FrameSettings").gameObject.SetActive(false);
        transform.Find("FrameMenu").Find("FrameInicio").gameObject.SetActive(true);
        transform.Find("Sonidos").Find("ClickAceptar").GetComponent<AudioSource>().Play();
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
    }
    private void guardarSettings()
    {
        Settings configuracionModificada = transform.GetComponent<SettingsLocal>().leerSettings();
        if (transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaIngles").Find("RadioActivado").gameObject.activeInHierarchy)
            configuracionModificada.setIdioma(0);
        else if (transform.Find("FrameMenu").Find("FrameSettings").Find("ButtonIdiomaEsp").Find("RadioActivado").gameObject.activeInHierarchy)
            configuracionModificada.setIdioma(1);

        //...... 
        transform.GetComponent<SettingsLocal>().guardarSettings(configuracionModificada);
    }


}
