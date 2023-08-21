using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Transform marioSprite;
    float velocidad = 9;
    

    // Start is called before the first frame update
    void Start()
    {

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
            marioSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
        else
        {
            marioSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
    }
}
