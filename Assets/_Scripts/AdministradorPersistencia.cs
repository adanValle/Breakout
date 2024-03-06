using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdministradorPersistencia : MonoBehaviour
{
    public List<PuntajePersistente> objetoGuardar;

    public void OnEnable()
    {
        for (int i = 0; i < objetoGuardar.Count; i++)
        {
            var so = objetoGuardar[i];
            so.Cargar();
        }
    }

    public void OnDisable()
    {
        for (int i = 0; i < objetoGuardar.Count; i++)
        {
            var so = objetoGuardar[i];
            so.Guardar();
        }
    }
}
