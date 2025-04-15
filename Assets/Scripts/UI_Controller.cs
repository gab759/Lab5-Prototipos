using UnityEngine;
using TMPro;

public class UI_Controller : MonoBehaviour
{
    [SerializeField] private TMP_Text textAbility;
    [SerializeField] private Heroe heroeRef;

    private void Start()
    {
        if (heroeRef != null)
        {
            heroeRef.onAbilityStolen += UpdateUI;
        }
    }

    public void UpdateUI(string name)
    {
        if (textAbility != null)
        {
            textAbility.text = "Habilidad robada: " + name;
        }
    }
}
