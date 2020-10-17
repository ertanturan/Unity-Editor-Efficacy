using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonComponent : MonoBehaviour
{

    private Button _button;

    private UnityAction _actionButtonClick;

    protected virtual void Awake()
    {

        _actionButtonClick += OnButtonClick;

        _button = GetComponent<Button>();
        _button.onClick.AddListener(_actionButtonClick);
    }

    protected virtual void OnButtonClick()
    {
        Debug.Log("Button Clicked -base-");
    }

}
