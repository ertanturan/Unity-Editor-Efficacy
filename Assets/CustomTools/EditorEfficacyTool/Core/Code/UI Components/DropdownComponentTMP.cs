using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TMP_Dropdown))]
public class DropdownComponentTMP : MonoBehaviour
{

    private TMP_Dropdown _dd;
    private UnityAction<int> _actionOnValueChange;

    protected virtual void Awake()
    {
        _dd = GetComponent<TMP_Dropdown>();
        _actionOnValueChange += OnValueChange;

        _dd.onValueChanged.AddListener(_actionOnValueChange);
    }

    protected virtual void OnValueChange(int value)
    {
        Debug.Log("On value change -base- :" + value);
    }

}
