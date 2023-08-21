using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.Mathematics;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class MarioMovement : MonoBehaviour
{
    public InputField rotacionF;
    public InputField escF;
    public InputField sesgaF;
    private int velocity = 10;
    private Vector3 defaultScale;
    public Button okButton;

    // Start is called before the first frame update
    void Start()
    {
        okButton.onClick.AddListener(buttonClicked);
        defaultScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        float inputV= Input.GetAxis("Vertical") * Time.deltaTime * velocity;
        float inputH = Input.GetAxis("Horizontal") * Time.deltaTime * velocity;
        transform.position = transform.position + new Vector3(inputH, inputV, 0);
        if (Input.GetKey(KeyCode.M))
            transform.localScale += new Vector3(0.01f, 0.01f, 0);
        else if (Input.GetKey(KeyCode.N) && transform.localScale.x > 0 && transform.localScale.y > 0)
            transform.localScale += new Vector3(-0.01f, -0.01f, 0);
    }

    void buttonClicked()
    {
        float rotacion = Convert.ToSingle(rotacionF.text);
        float escala = Convert.ToSingle(escF.text);
        Debug.Log(rotacion);
        Debug.Log(escala);
        transform.rotation = quaternion.RotateZ(Convert.ToInt32(rotacion) * Mathf.Deg2Rad);
        transform.localScale = transform.localScale += new Vector3(escala, escala, 0);
    }
}
