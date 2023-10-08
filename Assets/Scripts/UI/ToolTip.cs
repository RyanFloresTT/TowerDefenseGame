using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static Action<bool> OnToolTipStatusChanged;

    public void OnPointerEnter(PointerEventData eventData) {
        OnToolTipStatusChanged?.Invoke(true);
    }

    public void OnPointerExit(PointerEventData eventData) {
        OnToolTipStatusChanged?.Invoke(false);
    }
}
