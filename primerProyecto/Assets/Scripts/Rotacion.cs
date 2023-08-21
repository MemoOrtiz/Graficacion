using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotacion : MonoBehaviour
{
    public InputField rotacionXInput;
    public InputField rotacionYInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotacionX = float.Parse(rotacionXInput.text);
        float rotacionY = float.Parse(rotacionYInput.text);
        transform.Rotate(new Vector3(rotacionX, rotacionY, 0)* Time.deltaTime);

    }
}
