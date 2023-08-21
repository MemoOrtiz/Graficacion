using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pezSpoler : MonoBehaviour
{
    [SerializeField] private GameObject pezPrefab;
    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime = spawnTime - Time.deltaTime;
        if (spawnTime <= 0)
        {
            Instantiate(pezPrefab, GetSpamPosition(), Quaternion.identity);
            spawnTime = 1.5f;
        }
    }

    private Vector3 GetSpamPosition()
    {
        Vector2 limitesPantalla = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        float aleatorioVectical = Random.Range(-limitesPantalla.y, limitesPantalla.y);
        float aleatorioHorizontal = Random.Range(0, 2) == 0 ? -limitesPantalla.x - 1 : limitesPantalla.x + 1;

        return new Vector3(aleatorioHorizontal, aleatorioVectical, 0);
    }
}
