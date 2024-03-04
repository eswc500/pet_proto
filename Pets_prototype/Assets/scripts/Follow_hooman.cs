using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_hooman : MonoBehaviour
{
    public Transform target; // El objeto que seguirá la interfaz de usuario

    void LateUpdate()
    {
        if (target != null)
        {
            // Convierte la posición del objeto de la escena a la posición de la cámara de la interfaz de usuario
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(target.position);
            // Actualiza la posición del objeto de la interfaz de usuario para que coincida con la posición del objeto en la escena
            transform.position = targetPosition;
        }
    }
}
