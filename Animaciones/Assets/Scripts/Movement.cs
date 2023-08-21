using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 20.0f;
    public float rotationSpeed = 200.0f;
    private Animator anim;
    public float x, y;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * rotationSpeed, 0);
        transform.Translate(0, 0, y * Time.deltaTime * movementSpeed);
        //rb.AddForce(transform.forward * y * movementSpeed, ForceMode.Force);

        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);
    }
}
