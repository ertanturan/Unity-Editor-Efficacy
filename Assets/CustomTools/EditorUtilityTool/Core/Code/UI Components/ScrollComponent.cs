using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(ScrollRect))]
public class ScrollComponent : MonoBehaviour
{

    private UnityAction<Vector2> _actionValueChange;

    private ScrollRect _scrollRect;


    protected virtual void Awake()
    {
        _actionValueChange += OnValueChange;

        _scrollRect.onValueChanged.AddListener(OnValueChange);
    }

    protected virtual void OnValueChange(Vector2 value)
    {
        Debug.Log("Scroll rect value changed -base- : " + value);
    }

}
