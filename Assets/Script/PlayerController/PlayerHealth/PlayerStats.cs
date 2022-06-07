using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("A�l�k Sistemi")]
    [SerializeField] float _hunger;
    [SerializeField] Slider _hungerSlider;
    float maxHunger;

    [Header("Susuzluk Sistemi")]
    [SerializeField] float _thirst;
    [SerializeField] Slider _thirstSlider;
    float maxThirst;

    [Header("Can Sistemi")]
    [SerializeField] float _health;
    public Slider _healthSlider;
    float maxHealth;

  

    private void Awake()
    {
        _hunger = _hungerSlider.value;
        _thirst = _thirstSlider.value;
        _health = _healthSlider.value;
    }

    private void Start()
    {
        maxThirst = 100;
        maxHunger = 100;
        maxHealth = 100;
    }

    private void Update()
    {
        _hungerSlider.value = _hunger;
        _thirstSlider.value = _thirst;
        _healthSlider.value = _health;

        //A�l�k
        _hunger -= 0.1f * Time.deltaTime;

        //A�l�k S�n�r�
        if (_hunger >= maxHunger)
        {
            _hunger = maxHunger;
        }

        if (_hunger <= 0)
        {
            _hunger = 0;
            _health -= 0.05f * Time.deltaTime;
        }

        //Susuzluk
        _thirst -= 0.2f * Time.deltaTime;

        //Susuzluk S�n�r�
        if (_thirst >= maxThirst)
        {
            _thirst = maxThirst;
        }

        if (_thirst <= 0)
        {
            _thirst = 0;
            _health -= 2f * Time.deltaTime;
        }

        //Hasar alma test.
        if (Input.GetKeyDown(KeyCode.H))
        {
            _health -= 20;
        }

        //Kaydetme test.
        if (Input.GetKeyDown(KeyCode.L))
        {
            PlayerPrefs.SetFloat("Hunger", _hunger);
            PlayerPrefs.SetFloat("Thirst", _thirst);
            PlayerPrefs.SetFloat("Health", _health);
        }
    }
}
