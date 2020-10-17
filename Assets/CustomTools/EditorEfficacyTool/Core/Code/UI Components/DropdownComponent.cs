using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[RequireComponent(typeof(Dropdown))]
public class DropdownComponent : MonoBehaviour
{

    private UnityAction<int> _actionValueChange;
    private Dropdown _dropdown;

    protected virtual void Awake()
    {
        _actionValueChange += OnValueChange;

        _dropdown = GetComponent<Dropdown>();

        _dropdown.onValueChanged.AddListener(_actionValueChange);
    }

    protected virtual void OnValueChange(int value)
    {
        Debug.Log("Dropdown value changed -base- : " + value);
    }

}
