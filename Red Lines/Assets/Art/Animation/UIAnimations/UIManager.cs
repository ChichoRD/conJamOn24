using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _noticia;
    [SerializeField]
    private Animator _transicion;
    [SerializeField]
    private Animator _buttonSkipAnimator;
    [SerializeField]
    private GameObject _pauseMenu;
    private bool _boolSkip = false;
    private bool _boolVentana = false;
    private bool _pausado = false;
    void Start() {
        _noticia.SetActive(false);
        _pauseMenu.SetActive(false);
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

        // Desactiva la animaci髇
        _transicion.SetBool("Activo", false);
        _boolSkip = false;
    }
    public void Pausa()
    {
        Time.timeScale = 0f;
        _pauseMenu.SetActive(true);
    }
    public void Quit()
    {
        SceneManager.LoadScene("GameStartMenu");
    }
    public void Reanudar()
    {
        Time.timeScale = 1f;
        _pauseMenu.SetActive(false);
        _pausado = false;
    }
    public void Reiniciar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
