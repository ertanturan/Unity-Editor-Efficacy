using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderComponent : MonoBehaviour
{
    private UnityAction<float> _actionValueChange;

    private Slider _slider;

    protected virtual void Awake()
    {
        _actionValueChange += OnValueChange;

        _slider = GetComponent<Slider>();
        _slider.onValueChanged.AddListener(_actionValueChange);
    }

    protected virtual void OnValueChange(float value)
    {
        Debug.Log("Slider on value change -base- :" + value);
    }

}
