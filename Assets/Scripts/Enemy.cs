using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string habilidad = "Bola de fuego";

    public string GetHabilidad()
    {
        return habilidad;
    }
}
