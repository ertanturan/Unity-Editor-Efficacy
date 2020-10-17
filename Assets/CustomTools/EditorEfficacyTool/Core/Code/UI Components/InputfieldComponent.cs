using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(InputField))]
public class InputfieldComponent : MonoBehaviour
{
    private UnityAction<string> _actionValueChange;
    private UnityAction<string> _actionValueEditEnd;

    private InputField _field;


    protected virtual void Awake()
    {
        _field = GetComponent<InputField>();

        _actionValueChange += OnValueChange;
        _actionValueEditEnd += OnEditEnd;

        _field.onValueChanged.AddListener(_actionValueChange);
        _field.onEndEdit.AddListener(_actionValueEditEnd);
    }

    protected virtual void OnValueChange(string text)
    {
        Debug.Log("Input field on value change -base- :" + text);
    }

    protected virtual void OnEditEnd(string text)
    {
        Debug.Log("Input field on edit end -base- :" + text);
    }
}
