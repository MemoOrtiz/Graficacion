using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator what()
    {
        while (true)
        {
            Instantiate(obstacles[1], transform.position, Quaternion.identity);
            
        }

    }
}
