using System;
using UnityEngine;

public abstract class Ability
{
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public Action onUse;
    public GameObject Prefab;

    public Ability(string name, Action onUse, GameObject prefab = null)
    {
        this.Name = name;
        this.onUse = onUse;
        this.Prefab = prefab;
    }

    public void Use()
    {
        onUse?.Invoke();
    }
}