using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    bool isLeft = false;
    bool isRight = false;
    bool isJumping = false;
    bool isFloor = false;

    public Rigidbody2D rb;  
    public float velocidad;
    public float velocidadControles;
    public float salto;
    public LayerMask capaSuelo;
    public AudioClip sonidoMovimiento;
    public AudioManager audioManager;
    public AudioClip sonidoSalto;
    // public AudioClip sonidoMovimiento;
    public AudioClip inicioJuegoAudio;
    public Animator anim;
    public SpriteRenderer spr;

    private AudioSource audioSource;
    private BoxCollider2D boxCollider;

    private bool mirandoDerecha;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Piso")
        {
            isFloor = true;
        }
     }
    // void OnCollisionExit2D(Collision2D collision)
    // {
    //     if (collision.gameObject.tag == "Piso")
    //     {
    //         isFloor = false;
    //     }
    // }
    private void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ClickJump();
        }
    }

    public void clickLeft()
    {
        isLeft = true;
        anim.SetTrigger("run");
        spr.flipX = true;
    }

    public void releaseLeft()
    {
        isLeft = false;
        anim.SetTrigger("idle");
    }

    public void clickRight()
    {
        isRight = true;
        anim.SetTrigger("run");
        spr.flipX = false;
    }

    public void releaseRight()
    {
        isRight = false;
        anim.SetTrigger("idle");
    }

    public void ClickJump()
    {
        if (isFloor)
        {
            isFloor = false;
            isJumping = true;
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();

        if (inicioJuegoAudio != null)
        {
            audioSource.clip = inicioJuegoAudio;
            audioSource.Play();
        }
    }
    private void FixedUpdate()
    {
        if (isLeft)
        {
            rb.AddForce(new Vector2(-velocidadControles, 0) * Time.deltaTime);
            // audioManager.ReproducirSonido(sonidoMovimiento);
        }

        if (isRight)
        {
            rb.AddForce(new Vector2(velocidadControles, 0) * Time.deltaTime);
            // audioManager.ReproducirSonido(sonidoMovimiento);
        }

        if (isJumping)
        {
            isJumping = false;
            rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            audioManager.ReproducirSonido(sonidoSalto);
        }
    }


//     void MovimientoH()
//     {
//         float inputMovimiento = Input.GetAxis("Horizontal");

//         if (inputMovimiento != 0f)
//         {
//             rb.velocity = new Vector2(inputMovimiento * velocidad, rb.velocity.y);

//             Orientacion(inputMovimiento);

//             audioManager.ReproducirSonido(sonidoMovimiento);

// //            animator.SetBool("isRunning", true );
//         }
//         else
//         {
// //            animator.SetBool("isRunning", false );
//         }
//     }

     void Orientacion(float inputMovimiento)
    {
        if ((mirandoDerecha == false && inputMovimiento < 0) || (mirandoDerecha == true && inputMovimiento > 0))
        {
            mirandoDerecha = !mirandoDerecha;
            if (mirandoDerecha){
                spr.flipX = true;
            }
            else{
                spr.flipX = false;
            }
            //transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }
    }
}