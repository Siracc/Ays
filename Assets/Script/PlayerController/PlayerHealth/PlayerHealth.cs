using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Slider _healthSlider;
    [SerializeField] float _health;

    float _maxHEalth = 100;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.H))
        {
            GetDamage(10);
        }
        _healthSlider.value = _health;

    }


    public void GetDamage(float amount)
    {
        _health += amount;
        //_healthSlider.value = _health;
    }

}
