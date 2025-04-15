using System;
using UnityEngine;

public class Heroe : MonoBehaviour
{
    public Action<string> onAbilityStolen;

    [SerializeField] private Enemy enemyRef;
    private Ability abilityRef;
    private bool habilidadFueRobada = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("Presionaste R");
            RobarHabilidad(enemyRef);
            habilidadFueRobada = true;
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            Debug.Log("Presionaste U");

            if (habilidadFueRobada)
            {
                habilidadFueRobada = false;
                Debug.Log("Esperando un frame antes de usar la habilidad...");
                return;
            }

            UseAbility();
        }
    }

    public void RobarHabilidad(Enemy enemy)
    {
        if (enemy == null)
        {
            Debug.LogWarning("Enemy es null. No se puede robar la habilidad.");
            return;
        }

        string nombre = enemy.GetHabilidad();
        Debug.Log("Habilidad robada correctamente: " + nombre);

        abilityRef = new Ability(nombre, () =>
        {
            Debug.Log("Usando habilidad robada: " + nombre);
        });

        onAbilityStolen?.Invoke(nombre);
    }

    public void UseAbility()
    {
        if (abilityRef != null)
        {
            Debug.Log("Usando habilidad: " + abilityRef.name);
            abilityRef.Use();
        }
        else
        {
            Debug.Log("No se ha robado ninguna habilidad aún.");
        }
    }
}