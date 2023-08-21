using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Traslacion : MonoBehaviour
{
    

    
    // Start is called before the first frame update
    void Start()
    {
        

    }

    
    public InputField desplazamientoXInput;
    public InputField desplazamientoYInput;
    // Update is called once per frame
    void RealizarTraslacion()
    {
        float desplazamientoX = float.Parse(desplazamientoXInput.text);
        float desplazamientoY = float.Parse(desplazamientoYInput.text);

        Vector3 desplazamiento = new Vector3(desplazamientoX, desplazamientoY, 0f);

        transform.Translate(desplazamiento);
    
    }
}
