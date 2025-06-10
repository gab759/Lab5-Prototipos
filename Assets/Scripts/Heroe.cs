using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Heroe : MonoBehaviour
{
    public Action<string> onAbilityStolen;

    [SerializeField] private Enemy enemyRef;
    private Ability abilityRef;

    public void RobarHability(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            RobarHabilidad(enemyRef);
        }
    }
    public void Userhability(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            UseAbility();
        }
    }

    public void RobarHabilidad(Enemy enemy)
    {
        string nombre = enemy.GetHabilidad();
        GameObject prefab = enemy.GetFirePrefab();
        Debug.Log("Habilidad robada correctamente: " + nombre);

        abilityRef = new Habilidad(nombre, () =>
        {
            Debug.Log("Usando habilidad robada: " + nombre);
            if (prefab != null)
            {
                GameObject fuego = GameObject.Instantiate(
                    prefab,
                    transform.position + Vector3.up * 2f,
                    Quaternion.identity
                );
                GameObject.Destroy(fuego, 3f);
            }
        }, prefab);

        onAbilityStolen?.Invoke(nombre);
    }

    public void UseAbility()
    {
        if (abilityRef != null)
        {
            Debug.Log("Usando habilidad: " + abilityRef.Name);
            abilityRef.Use();
        }
    }
}