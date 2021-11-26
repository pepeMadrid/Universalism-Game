using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionPorTiempo : MonoBehaviour
{
    public float x = 0f;
    public float y = 0f;
    public float z = 0f;
    public bool activo;
    void Start()
    {
        StartCoroutine(rotacionPorTiempo());
    }

    IEnumerator rotacionPorTiempo()
    {
        yield return new WaitForSeconds(0.05f);
        if (activo)
            transform.Rotate(x, y, z);
        StartCoroutine(rotacionPorTiempo());
    }
}
