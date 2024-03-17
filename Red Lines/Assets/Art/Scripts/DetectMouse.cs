using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectMouse : MonoBehaviour
{
    [SerializeField] private GameObject ventanaEmergente; // Referencia al GameObject de la ventana emergente

    void OnMouseEnter() {
        // Mostrar la ventana emergente cuando el rat�n entra en el �rea del pa�s
        ventanaEmergente.SetActive(true);
    }

    void OnMouseExit() {
        // Ocultar la ventana emergente cuando el rat�n sale del �rea del pa�s
        ventanaEmergente.SetActive(false);
    }
}
