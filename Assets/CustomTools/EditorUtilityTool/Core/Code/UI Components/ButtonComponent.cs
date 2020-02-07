using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonComponent : MonoBehaviour
{

    private Button _button;

    private UnityAction ActionButtonClick;

    protected virtual void Awake()
    {

        ActionButtonClick += OnButtonClick;

        _button = GetComponent<Button>();
        _button.onClick.AddListener(ActionButtonClick);
    }

    protected virtual void OnButtonClick()
    {
        Debug.Log("Button Clicked -base-");
    }

}
