using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour
{
    [SerializeField] private CanvasGroup _group;
    [SerializeField] private Button _button;
    [SerializeField] private Bird _bird;

    public event UnityAction ButtonClicked;

    private void OnEnable()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        ButtonClicked?.Invoke();
    }

    public void Open()
    {
        _group.alpha = 1f;
        _button.interactable = true;
    }

    public void Close()
    {
        _group.alpha = 0f;
        _button.interactable = false;
    }
}
