using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class TraductorIdiomas : MonoBehaviour
{
    private readonly string archivoESP = "/idiomaESP.f1rstree";
    private readonly string archivoIngles = "/idiomaingles.f1rstree";

    void Awake()
    {
        inicializamosTextosEnArchivos();
    }


    private void inicializamosTextosEnArchivos()
    {
        //ESP
        ArrayList ESPtextosArray = new ArrayList();
        ESPtextosArray.Add(new Texto("Inicio", "Esto es el inicio del juego"));
        ESPtextosArray.Add(new Texto("ErrorNombreExiste", "Ya existe una partida con ese nombre, por favor introduce otro nombre"));
        Textos ESPtextos = new Textos(1, ESPtextosArray);

        if (!File.Exists(Application.persistentDataPath + archivoESP))
        {
            BinaryFormatter bf;
            FileStream file;
            bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + archivoESP);
            bf.Serialize(file, ESPtextos);
            file.Close();
        }

        //Ingles
        ArrayList InglestextosArray = new ArrayList();
        InglestextosArray.Add(new Texto("Inicio", "This is the start of the game"));
        InglestextosArray.Add(new Texto("ErrorNombreExiste", "There is already a game with that name, please enter another name"));
        Textos Inglestextos = new Textos(0, InglestextosArray);

        if (!File.Exists(Application.persistentDataPath + archivoIngles))
        {
            BinaryFormatter bf;
            FileStream file;
            bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + archivoIngles);
            bf.Serialize(file, Inglestextos);
            bf.Serialize(file, Inglestextos);
            file.Close();
        }
    }

    public string busquedaPorID(string id)
    {//Search a una BD orientada a objetos
        string nombreArchivo = archivoIngles;
        print("settings " + transform.GetComponent<SettingsLocal>().leerSettings().getIdioma());
        if (transform.GetComponent<SettingsLocal>().leerSettings().getIdioma() == 0)
            nombreArchivo = archivoIngles;
        else if (transform.GetComponent<SettingsLocal>().leerSettings().getIdioma() == 1)
            nombreArchivo = archivoESP;

        BinaryFormatter bf;
        FileStream file;
        Textos archivoTextos = new Textos();
        
        if (File.Exists(Application.persistentDataPath + nombreArchivo))
        {
            bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + nombreArchivo, FileMode.Open);
            archivoTextos = (Textos)bf.Deserialize(file);
            file.Close();
        }
        print("Archivo "+ archivoTextos.getIdioma());
        //recorremos array en busca de la id
        foreach (Texto textObj in archivoTextos.getAlltext())
        {
            print("busquedas " + textObj.getID());

            if (textObj.getID().Equals(id))
            {//busqueda con exito
                print("nice");
                return textObj.getContenido();
            }
        }
        return "NULL";
    }


    [System.Serializable]
    private class Textos
    {
        private int idioma;
        private ArrayList textosArray;

        public Textos(int idioma, ArrayList textosArray)
        {
            this.idioma = idioma;
            this.textosArray = textosArray;
        }
        public Textos()
        {

        }
        public ArrayList getAlltext()
        {
            return this.textosArray;
        }
        public int getIdioma()
        {
            return this.idioma;
        }

    }

    [System.Serializable]
    private class Texto
    {
        private string id;
        private string contenido;
        public Texto(string id,string contenido)
        {
            this.id = id;
            this.contenido = contenido;
        }
        public string getID()
        {
            return this.id;
        }
        public string getContenido()
        {
            return this.contenido;
        }
    }
}



