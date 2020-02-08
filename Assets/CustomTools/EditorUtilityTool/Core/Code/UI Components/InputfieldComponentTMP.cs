using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_InputField))]
public class InputfieldComponentTMP : MonoBehaviour
{

    private TMP_InputField _field;

    private UnityAction<string> _actionOnValueChange;

    private UnityAction<string> _actionOnEditEnd;

    private UnityAction<string> _actionOnSelect;

    private UnityAction<string> _actionOnDeselect;


    protected virtual void Awake()
    {
        _field = GetComponent<TMP_InputField>();

        _actionOnSelect += OnSelect;
        _actionOnDeselect += OnDeselect;
        _actionOnEditEnd += OnEditEnt;
        _actionOnValueChange += OnValueChange;

        _field.onSelect.AddListener(_actionOnSelect);
        _field.onDeselect.AddListener(_actionOnDeselect);
        _field.onEndEdit.AddListener(_actionOnEditEnd);
        _field.onValueChanged.AddListener(_actionOnValueChange);
    }

    protected virtual void OnValueChange(string value)
    {
        Debug.Log("On value change -base- :" + value);
    }

    protected virtual void OnEditEnt(string value)
    {
        Debug.Log("On edit end -base- :" + value);

    }

    protected virtual void OnSelect(string value)
    {
        Debug.Log("On select -base- :" + value);

    }

    protected virtual void OnDeselect(string value)
    {
        Debug.Log("On Deselect -base- :" + value);

    }

}
