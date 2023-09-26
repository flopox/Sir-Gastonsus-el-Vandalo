using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicial : MonoBehaviour
{
    public string nombreDeLaEscenaACargar = "Nivel1"; // Nombre de la escena que deseas cargar

    public void Jugar()
    {
        SceneManager.LoadScene(nombreDeLaEscenaACargar);
    }

    public void Salir()
    {
        Debug.Log("Salir...");
        Application.Quit();
    }
}