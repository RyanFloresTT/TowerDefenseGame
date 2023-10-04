using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "UI/CollapseEvent")]
public class UICollapse : ScriptableObject {
    public static Action OnCollapseUI;
    public void CollapseUI() => OnCollapseUI?.Invoke();
}
