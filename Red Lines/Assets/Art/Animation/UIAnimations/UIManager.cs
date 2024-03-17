using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _noticia;
    [SerializeField]
    private Animator _transicion;
    [SerializeField]
    private Animator _buttonSkipAnimator;
    private bool _boolSkip = false;
    private bool _boolVentana = false;
    void Start() {
        _noticia.SetActive(false);
    }
    
    public void AbrirCerrarVentana() {
        if (!_boolVentana) {
            _noticia.SetActive(true);
            _boolVentana = true;
        } else {
            _noticia.SetActive(false);
            _boolVentana = false;
        }
    }

    public void Skip() {
        if (!_boolSkip) {
            _buttonSkipAnimator.SetBool("Pressed", true);
            Invoke("StopANimator", 0.2f);
            _boolSkip=true;
        }
    }

    private void StopANimator() {
        _buttonSkipAnimator.SetBool("Pressed", false);
        _transicion.SetBool("Activo", true); 
        StartCoroutine(DesactivarAnimacionDespuesDeTiempo(1f));
    }

    IEnumerator DesactivarAnimacionDespuesDeTiempo(float tiempo) {
        // Espera el tiempo especificado
        yield return new WaitForSeconds(tiempo);

        // Desactiva la animación
        _transicion.SetBool("Activo", false);
        _boolSkip = false;
    }

}
