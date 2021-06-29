public class BooleanUITextController : AUITextController<bool>
{
    protected override void UpdateUI(bool value)
    {
        if (value)
            uiText.text = $"{text}";
        else
            uiText.text = string.Empty;
    }
}