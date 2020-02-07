using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


[RequireComponent(typeof(Toggle))]
public class ToggleComponent : MonoBehaviour
{
    private UnityAction<bool> _actionValueChange;
    private Toggle _toggle;


    protected virtual void Awake()
    {
        _actionValueChange += OnValueChange;
        _toggle = GetComponent<Toggle>();

        _toggle.onValueChanged.AddListener(_actionValueChange);
    }

    protected virtual void OnValueChange(bool value)
    {
        Debug.Log("Toggle value changed -base-");
    }


}
