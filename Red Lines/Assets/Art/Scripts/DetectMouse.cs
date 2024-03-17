using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouse : MonoBehaviour
{
    [SerializeField] private GameObject ventanaEmergente; // Referencia al GameObject de la ventana emergente

    void OnMouseEnter() {
        // Mostrar la ventana emergente cuando el ratón entra en el área del país
        ventanaEmergente.SetActive(true);
    }

    void OnMouseExit() {
        // Ocultar la ventana emergente cuando el ratón sale del área del país
        ventanaEmergente.SetActive(false);
    }
}
