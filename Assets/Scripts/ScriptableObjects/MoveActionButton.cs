using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ActionButtons/Move")]
public class MoveActionButton : MenuButton {
    public static Action OnMovePrimed;
    public override void OnButtonPressed() {
        OnMovePrimed?.Invoke();
    }
}