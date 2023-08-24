using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D rb2d;

    [SerializeField] private float velocidadMovimiento;

    [SerializeField] private float Distancia;

    [SerializeField] private LayerMask queEsSuelo;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        rb2d.velocity = new Vector2(velocidadMovimiento * transform.right.x, rb2d.velocity.y);

        RaycastHit2D informacionSuelo = Physics2D.Raycast(transform.position, transform.right, Distancia, queEsSuelo);
        if (informacionSuelo)
        {
            Girar();
        }
    }
    private void Girar()
    {
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 120, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + transform.right * Distancia);

    }


}
