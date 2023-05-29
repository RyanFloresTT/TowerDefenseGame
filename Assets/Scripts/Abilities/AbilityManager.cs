using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityManager : MonoBehaviour
{
    [SerializeField] private Ability[] abilities;
    [SerializeField] private AbilityButton abilityButtonPrefab;
    [SerializeField] private Transform abilityContainer;

    public static AbilityManager Instance;
    private AbilityButton currentAbilityButton;
    private Ability currentAbility;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new();
        inputActions.Player.LeftClick.performed += Handle_LeftClick;
        Instance = this;
    }

    private void Start()
    {
        foreach (var ability in abilities)
        {
            ability.Initialize();
            CreateNewAbilityButton(ability);
        }

        currentAbilityButton = null;
    }

    private void OnEnable()
    {
        inputActions.Player.LeftClick.Enable();
    }

    private void OnDisable()
    {
        inputActions.Player.LeftClick.Disable();
    }

    private void Handle_LeftClick(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        currentAbility?.StartAbility();
    }

    public void ChangeSelectedAbility(AbilityButton abilityButton)
    {
        currentAbilityButton?.DeselectAbility();
        currentAbilityButton = abilityButton;
        currentAbilityButton.SelectAbility();
        currentAbility = currentAbilityButton.Ability;
    }

    private void CreateNewAbilityButton(Ability ability)
    {
        var button = Instantiate(abilityButtonPrefab);
        button.transform.parent = abilityContainer;
        button.GetComponent<Button>().image.sprite = ability.GetAbilityIcon();
        button.Ability = ability;
    }
}
