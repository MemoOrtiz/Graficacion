using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    private TMP_Text puntosTexto;
    public void Awake()
    {
        puntosTexto = GetComponent<TMP_Text>();
    }
    public void ActualizarPuntos(int puntos)
    {
        puntosTexto.text = "Peces comidos: " + puntos.ToString();
    }
}
