using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ActionButtons/ExitButton")]
public class ExitActionButtonMenu : MenuButton
{
    public static Action OnExitMenuPressed;
    public override void OnButtonPressed() {
        OnExitMenuPressed?.Invoke();
    }
}
