using System;
using UnityEngine;

public class Habilidad : Ability
{
    public Habilidad(string name, Action onUse, GameObject prefab = null)
        : base(name, onUse, prefab)
    {
    }
}