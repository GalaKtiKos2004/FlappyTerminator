using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class Window : MonoBehaviour
{
    private const float MinTransparency = 0f;
    private const float MaxTransparency = 1f;

    [SerializeField] private Button _actionButton;

    private CanvasGroup _windowGroup;

    public event Action ButtonClicked;

    private void Awake()
    {
        _windowGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        _actionButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _actionButton.onClick.RemoveListener(OnButtonClick);
    }

    public void Open()
    {
        _windowGroup.alpha = MaxTransparency;
        _actionButton.interactable = true;
    }
    public void Close()
    {
        _windowGroup.alpha = MinTransparency;
        _actionButton.interactable = false;
    }

    private void OnButtonClick()
    {
        ButtonClicked?.Invoke();
    }
}