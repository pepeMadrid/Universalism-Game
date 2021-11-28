using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.AI;
using System.IO;

public class SettingsLocal : MonoBehaviour
{
    private readonly string nombreArchivo = "/settings.f1rstree";

    void Awake()
    {
        crearArchivo();
    }

    private void crearArchivo()
    {
        //si no existe el archivo lo crearemos y guardaremos los valores por defecto
        if (!File.Exists(Application.persistentDataPath + nombreArchivo))
        {
            BinaryFormatter bf;
            FileStream file;
            Settings configuracionJuego = new Settings();
            bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + nombreArchivo);
            bf.Serialize(file, configuracionJuego);
            file.Close();
        }
    }

    public Settings leerSettings()
    {
        BinaryFormatter bf;
        FileStream file;
        Settings settingsArchivo = new Settings();

        if (File.Exists(Application.persistentDataPath + nombreArchivo))
        {
            bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + nombreArchivo, FileMode.Open);
            settingsArchivo = (Settings)bf.Deserialize(file);
            file.Close();
        }

        return settingsArchivo;
    }

    public void guardarSettings(Settings configuracion)
    {
        if (File.Exists(Application.persistentDataPath + nombreArchivo))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + nombreArchivo);

            bf.Serialize(file, configuracion);
            file.Close();
        }
    }


    [System.Serializable]
    public class Settings
    {
        private int idioma; //0 ingles - 1 español ....
        private float volumenMusica; //0-1
        private float volumenSonidos; //0-1
        //.....
        public Settings ()
        { //valores defecto
            this.idioma = 0;
            this.volumenMusica = 1;
            this.volumenSonidos = 1;
            //.....
        }

        public void setIdioma(int n)
        {
            this.idioma = n;
        }
        public int getIdioma()
        {
            return this.idioma;
        }
        public void setVolumenMusica(float n)
        {
            this.volumenMusica = n;
        }
        public float getVolumenMusica()
        {
            return this.volumenMusica;
        }
        public void setVolumenSonidos(float n)
        {
            this.volumenSonidos = n;
        }
        public float getVolumenSonidos()
        {
            return this.volumenSonidos;
        }
    }
}
