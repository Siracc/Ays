using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Açlýk Sistemi")]
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

    [Header("Stat Penceresi")]
    [SerializeField] GameObject _statScreen;

    private void Awake()
    {
        _hunger = PlayerPrefs.GetFloat("Hunger");
        _thirst = PlayerPrefs.GetFloat("Thirst");
        _health = PlayerPrefs.GetFloat("Health");
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

        //Açlýk
        _hunger -= 0.5f * Time.deltaTime;

        //Açlýk Sýnýrý
        if (_hunger >= maxHunger)
        {
            _hunger = maxHunger;
        }

        if (_hunger <= 0)
        {
            _hunger = 0;
            _health -= 0.5f * Time.deltaTime;
        }

        //Susuzluk
        _thirst -= 1f * Time.deltaTime;

        //Susuzluk Sýnýrý
        if (_thirst >= maxThirst)
        {
            _thirst = maxThirst;
        }

        if (_thirst <= 0)
        {
            _thirst = 0;
            _health -= 2f * Time.deltaTime;
        }

        //Taba basýldýðýnda ekranda göster.
        if (Input.GetKey(KeyCode.Tab))
        {
            _statScreen.SetActive(true);
        }

        else
        {
            _statScreen.SetActive(false);
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
