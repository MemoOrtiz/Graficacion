using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        transform.Translate(GameManager.Instance.GetScrollSpeed()* Time.deltaTime * Vector2.left);
    }
}
