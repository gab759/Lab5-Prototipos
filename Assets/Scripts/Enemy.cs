using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string habilidad = "Bola de fuego";
    [SerializeField] private GameObject firePrefab;
    private float timer = 0f;
    private float spawnInterval = 5f;

    public string GetHabilidad()
    {
        return habilidad;
    }
    public GameObject GetFirePrefab()
    {
        return firePrefab;
    }
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            CrearFuegoVisual();
            timer = 0f;
        }
    }

    private void CrearFuegoVisual()
    {
        if (firePrefab != null)
        {
            GameObject fuego = Instantiate(
                firePrefab,
                transform.position + Vector3.up * 2f,
                Quaternion.identity
            );
            Destroy(fuego, 3f);
        }
        else
        {
            Debug.LogWarning("No se ha asignado el prefab de fuego en el Enemy.");
        }
    }
}