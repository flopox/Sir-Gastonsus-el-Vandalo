using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public string nombreDeLaEscenaACargar = "Nivel2"; // Nombre de la escena que deseas cargar

    public void CambiarAEscenaDeseada()
    {
        SceneManager.LoadScene(nombreDeLaEscenaACargar);
    }
}