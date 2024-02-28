using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOptions : MonoBehaviour
{
    public RectTransform uiElement; // Reference to your UI element
    public Canvas canvas;

    public bool option1;

    public void EnableOptionsPage()
    {
        uiElement.localScale = Vector3.zero;
        canvas.enabled = true;

        uiElement.DOScale(Vector3.one, 1f).SetEase(Ease.OutBounce);

    }
}
