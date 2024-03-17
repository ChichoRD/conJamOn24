using ReignCollectionSystem;
using ReignSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DetectMouse : MonoBehaviour
{
    [SerializeField] private GameObject ventanaEmergente; // Referencia al GameObject de la ventana emergente
    [SerializeField] private ReignLayoutType _layoutType;
    [SerializeField] private ReignLayout _reignLayout;
    private string _water;
    private string _food;
    private string _agenda;
    private string _content;
    [SerializeField] private TextMeshProUGUI _texto;

    void OnMouseEnter() {
        // Mostrar la ventana emergente cuando el ratón entra en el área del país
        ventanaEmergente.SetActive(true);
        if (_reignLayout.TryGetReign(_layoutType, out Reign reign)) {
            _water = reign.Parameter.water.ToString();
            _food=reign.Parameter.food.ToString();
            _agenda=reign.Parameter.agenda.ToString();
            _content=reign.Parameter.content.ToString();
            _texto.text = "Agua: " + _water + "\n" +
                       "Comida: " + _food + "\n" +
                        "Población: " + _water + "\n" +
                        "Agenda: " + _agenda + "\n" +
                        "Satisfacción: " + _content;
        }
        
    }

    void OnMouseExit() {
        // Ocultar la ventana emergente cuando el ratón sale del área del país
        ventanaEmergente.SetActive(false);
    }
}
