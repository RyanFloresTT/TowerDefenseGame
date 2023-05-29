using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityButton : MonoBehaviour
{
    public Ability Ability { get; set; }

    [SerializeField] private GameObject selectionMarker;

    private AbilityManager abilityManager;

    private void Start()
    {
        abilityManager = AbilityManager.Instance;
        DeselectAbility();
    }

    public void Activate()
    {
        Ability.StartAbility();
    }

    public void SelectAbility()
    {
        selectionMarker.SetActive(true);
    }

    public void DeselectAbility()
    {
        selectionMarker.SetActive(false);
    }

    public void PrimeAbility()
    {
        abilityManager.ChangeSelectedAbility(this);
    }
}
