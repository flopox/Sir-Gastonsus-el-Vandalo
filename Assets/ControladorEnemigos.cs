using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ControladorEnemigos : MonoBehaviour
{

    private float minX, maxX, minY, maxY;

    [SerializeField] private Transform[] puntos;

    [SerializeField] private GameObject[] enemigos;

    [SerializeField] private float TiempoEnemigos;

    private float tiempoSiguienteEnemigo;

    private void Start()
{
    if (puntos.Length > 0)
    {
        maxX = puntos.Max(punto => punto.position.x);
        minX = puntos.Min(punto => punto.position.x);
        maxY = puntos.Max(punto => punto.position.y);
        minY = puntos.Min(punto => punto.position.y);
    }
    else
    {
        Debug.LogWarning("No se encontraron puntos en el array 'puntos'.");
    }
}



    private void Update()
    {
        tiempoSiguienteEnemigo += Time.deltaTime;

        if (tiempoSiguienteEnemigo >= TiempoEnemigos)
        {
            tiempoSiguienteEnemigo = 0;
            CrearEnemigos();
        }
    }

    private void CrearEnemigos()
    {
        int numeroEnemigos = Random.Range(0, enemigos.Length);
        Vector2 posicionAleatoria = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        Instantiate(enemigos[numeroEnemigos], posicionAleatoria, Quaternion.identity);
    }


}
