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

    public GameSlot leerDatosGuardados(string nombre)
    {
        BinaryFormatter bf;
        FileStream file;
        GameSlot datos = new GameSlot();

        if (File.Exists(Application.persistentDataPath + "/SAVE_" + nombre + ".f1rstree"))
        {
            bf = new BinaryFormatter();
            file = File.Open(Application.persistentDataPath + nombre, FileMode.Open);
            datos = (GameSlot)bf.Deserialize(file);
            file.Close();
        }

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
