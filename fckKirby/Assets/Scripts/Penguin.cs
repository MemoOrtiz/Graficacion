using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Penguin : MonoBehaviour
{
    // Start is called before the first frame update
    private float vel = 5;
    private float skewFactor = 1, currentZ, rZ, rX, rY, deg;

    float rotationSpeed = 40f;
    [SerializeField] private Button _button;
    void Start()
    {
        deg = 1f;
        _button.onClick.AddListener(restart);
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento en los ejes de x,y,z para mooder el modelo 3d /
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        currentZ = Input.GetKey("z") ? 1f : Input.GetKey("x") ? -1f : 0f;
        Vector3 movement = new Vector3(h, v, currentZ) * Time.deltaTime * vel;
        transform.position += movement;
        // Aqui se modifica la rotacion del objeto en los ejes x, y, z dependiendo del a tecla presionada /

        float rotationX = Input.GetKey("o") ? rotationSpeed * Time.deltaTime : 0f;
        float rotationY = Input.GetKey("p") ? rotationSpeed * Time.deltaTime : 0f;
        float rotationZ = Input.GetKey("i") ? rotationSpeed * Time.deltaTime : 0f;
        transform.rotation *= Quaternion.Euler(rotationX, rotationY, rotationZ);


        // Aqui se modifica la escala del objeto 3d /

        float scaleChange = 0.1f * Time.deltaTime;
        if (Input.GetKey(KeyCode.Equals) && Input.GetKey(KeyCode.LeftShift) || Input.GetKey("q"))
            transform.localScale += new Vector3(scaleChange, scaleChange, scaleChange);
        else if (Input.GetKey("r"))
            transform.localScale -= new Vector3(scaleChange, scaleChange, scaleChange);


        // Sesgado del modelo 3d /
        if (Input.GetKey("h"))
        {
            // Efecto de sesgado/
            Vector3 scale = transform.localScale;

            Matrix4x4 skewMatrix = Matrix4x4.identity;
            skewMatrix[1, 0] = skewFactor * scale.z; // Apply skew along the X-axis (Y -> X)

            Matrix4x4 transformedMatrix = Matrix4x4.TRS(transform.position, transform.rotation, scale) * skewMatrix;

            transform.rotation = transformedMatrix.rotation;
            transform.localScale = transformedMatrix.lossyScale;
        }
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

