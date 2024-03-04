using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_hooman : MonoBehaviour
{
    public Transform target; // El objeto que seguir� la interfaz de usuario

    void LateUpdate()
    {
        if (target != null)
        {
            // Convierte la posici�n del objeto de la escena a la posici�n de la c�mara de la interfaz de usuario
            Vector3 targetPosition = Camera.main.WorldToScreenPoint(target.position);
            // Actualiza la posici�n del objeto de la interfaz de usuario para que coincida con la posici�n del objeto en la escena
            transform.position = targetPosition;
        }
    }
}
