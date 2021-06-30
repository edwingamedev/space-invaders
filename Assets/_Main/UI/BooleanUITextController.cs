using UnityEngine;

public class BooleanUITextController : AUITextController<bool>
{
    [SerializeField] private bool startEnabled;

    private void Awake()
    {
        UpdateUI(startEnabled);
    }

    protected override void UpdateUI(bool value)
    {
        if (value)
            uiText.text = $"{text}";
        else
            uiText.text = string.Empty;
    }
}