using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


public class SaveLoadLocal : MonoBehaviour
{


    public int crearArchivo(string nombre,string fecha)
    {
        //si no existe el archivo lo crearemos y guardaremos los valores por defecto
        if (!File.Exists(Application.persistentDataPath +"/SAVE_"+ nombre+".f1rstree"))
        {
            BinaryFormatter bf;
            FileStream file;
            GameSlot slotInicial = new GameSlot(nombre,fecha);
            bf = new BinaryFormatter();

            file = File.Create(Application.persistentDataPath + "/SAVE_" + nombre + ".f1rstree");
            bf.Serialize(file, slotInicial);
            file.Close();

            return 0; // 0 = se a creado sin problemas
        }
        else
        {
            return 1; // 1 = el archivo ya existe
        }
    }

    public GameSlot leerDatosGuardados(string pathEntero)
    {
        BinaryFormatter bf;
        FileStream file;
        GameSlot datos = new GameSlot();

        bf = new BinaryFormatter();
        file = File.Open(pathEntero, FileMode.Open);
        datos = (GameSlot)bf.Deserialize(file);
        file.Close();

        return datos;
    }


    public void guardarDatos(GameSlot configuracion,string nombre)
    {
        if (File.Exists(Application.persistentDataPath + "/SAVE_" + nombre + ".f1rstree"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/SAVE_" + nombre + ".f1rstree");

            bf.Serialize(file, configuracion);
            file.Close();
        }
    }

    public GameSlot getArchivo(int n)
    {
        string[] archivos = Directory.GetFiles(Application.persistentDataPath);
        ArrayList saveSlots = new ArrayList();
        foreach (string fileName in archivos)
        {
            if (fileName.Contains("SAVE_"))
                saveSlots.Add(fileName);
        }
        return leerDatosGuardados(saveSlots[n].ToString());
    }

    public int numeroSlots()
    {
        string[] archivos = Directory.GetFiles(Application.persistentDataPath);
        int cantidad=0;
        foreach (string fileName in archivos)
        {
            if (fileName.Contains("SAVE_"))
            {
                cantidad++;
            }
        }
        return cantidad;
    }

    [System.Serializable]
    public class GameSlot
    {
        private string nombre;
        private string fechaCreacion;
        private string fechaModificacion;
        private string escena;

        public GameSlot(string nombre, string fechaCreacion )
        {
            this.nombre = nombre;
            this.fechaCreacion = fechaCreacion;
            this.escena = "MapaEstelar";
        }

        public GameSlot()
        {

        }
        public void setFechaModificacion(string fecha)
        {
            this.fechaModificacion = fecha;
        }
        public string getNombre()
        {
            return this.nombre;
        }
        public string getfechaCreacion()
        {
            return this.fechaCreacion;
        }
        public string getfechaModificacion()
        {
            return this.fechaModificacion;
        }
        public void setEscena(string escena)
        {
            this.escena = escena;
        }
        public string getEscena()
        {
            return this.escena;
        }


    }
}
