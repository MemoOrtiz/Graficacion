using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instancia { get; private set; }
    private MaquinadeEstados maquinadeEstados;
    [SerializeField] private GameObject perdistePanel;
    [SerializeField] private GameObject ganastePanel;

    private void Awake()
    {
        if (Instancia != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instancia = this;
        }
    }
    public void ActualizarMaquinadeEstados(MaquinadeEstados nuevoEstado)
    {
        switch (nuevoEstado)
        {
            case MaquinadeEstados.Jugando:
                break;
            case MaquinadeEstados.JuegoTerminado:
                perdistePanel.SetActive(true);
                break;
            case MaquinadeEstados.JuegoGanado:
                ganastePanel.SetActive(true);
                break;
            default:
                break;

        }
    }
}

public enum MaquinadeEstados
{
        Jugando,
        JuegoTerminado,
        JuegoGanado
}

