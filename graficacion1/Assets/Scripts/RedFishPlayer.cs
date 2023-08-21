using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFishPlayer : MonoBehaviour
{
    
    [SerializeField] private Transform pezSprite;
    float velocidad = 9;
    private int pecesComidos = 0;
    private float tamano;
    [SerializeField] private PlayerUI playerUI;

    // Start is called before the first frame update
    void Start()
    {
        tamano = transform.localScale.x;
    }

   
    void Update()
    {
        // Movimiento
        float inputVertical = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        float inputHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        transform.position = transform.position + new Vector3(inputHorizontal, inputVertical, 0);

        //Evitar salir de la pantalla
        Vector2 limitePantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, limitePantalla.x * -1, limitePantalla.x * +1),
            Mathf.Clamp(transform.position.y, limitePantalla.y * -1, limitePantalla.y * +1),
            0);
        // Rotacion
        if (inputHorizontal == 0) return;
        if (inputHorizontal < 0)
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            pezSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pez"))
        {
            PezAI pezAI = collision.gameObject.GetComponent<PezAI>();
            if (tamano >= pezAI.tamano)
            {
                pecesComidos++;
                playerUI.ActualizarPuntos(pecesComidos);
                transform.localScale = transform.localScale + new Vector3(0.1f, 0.1f, 0.1f);
                tamano = transform.localScale.x;
                Destroy(collision.gameObject);
                if (pecesComidos >= 10)
                {
                    GameManager.Instancia.ActualizarMaquinadeEstados(MaquinadeEstados.JuegoGanado);
                    velocidad = 0;
                }
            }
            else
            {
                GameManager.Instancia.ActualizarMaquinadeEstados(MaquinadeEstados.JuegoTerminado);
                Destroy(gameObject);

            }
        }
    }
    
}
