using EdwinGameDev.Events;
using UnityEngine;
using TMPro;

public abstract class AUITextController<T> : MonoBehaviour
{
    [SerializeField] protected ScriptableEvent<T> scriptableEvent;
    [SerializeField] protected TextMeshProUGUI uiText;
    [SerializeField] protected string text;

    // Start is called before the first frame update
    void Start()
    {
        scriptableEvent.Subscribe(UpdateUI);
    }

    protected virtual void UpdateUI(T value)
    {
        uiText.text = $"{text} {value}";
    }
}