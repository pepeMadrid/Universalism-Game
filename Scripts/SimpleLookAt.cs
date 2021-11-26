using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleLookAt : MonoBehaviour
{
    public GameObject target;
    public bool persistent;

    void Awake()
    {
        transform.LookAt(target.transform);
        if(persistent)
            StartCoroutine(actualizarLookAt());
    }

    IEnumerator actualizarLookAt()
    {
        yield return new WaitForSeconds(0.05f);
        transform.LookAt(target.transform);
        StartCoroutine(actualizarLookAt());
    }
}
