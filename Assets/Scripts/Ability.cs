using UnityEngine;
using System;
public class Ability : MonoBehaviour
{
    public string name;
    public Action onUse;

    public Ability(string name, Action onUse)
    {
        this.name = name;
        this.onUse = onUse;
    }

    public void Use()
    {
        onUse?.Invoke();
    }
}
