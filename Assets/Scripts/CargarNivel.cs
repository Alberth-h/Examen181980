using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Librerías
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CargarNivel : MonoBehaviour
{
    //Método para cargar escena (Nivel)
    public void CargarEscena(string NombreNivel)
    {
        SceneManager.LoadScene(NombreNivel);
    }
    //Método para salir
    public void Salir()
    {
        Application.Quit();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
