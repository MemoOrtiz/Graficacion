using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PezAI : MonoBehaviour
{
    [SerializeField] private Transform pezSprite;
    private int dir = 1;
    public float tamano;
    Vector2 limitesPantalla;
    [SerializeField] private float speed = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if (transform.position.x <= limitesPantalla.x / 2)
        {
            dir = 1;
            pezSprite.rotation = pezSprite.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            dir = -1;
            pezSprite.rotation = pezSprite.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }

        float randomSize = Random.Range(0.5f, 2.5f);
        tamano = randomSize;
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = transform.position + (Vector3.right * dir * Time.deltaTime * speed);
        if(transform.position.x <= -limitesPantalla.x-2 || transform.position.x > limitesPantalla.x + 2)
        {
            Destroy(gameObject);
        }
    }
    public float GetTamano()
    {
        return tamano;
    }
}
