using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStep : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;

    [SerializeField] AudioClip _grassSound, _stoneSound;
    [SerializeField] float _soundVolume;

    [SerializeField] int _soundNum;


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            _soundNum = 1;
            Debug.Log("1 oldu");
        }

        else if (other.gameObject.CompareTag("Stone"))
        {
            _soundNum = 2;
            Debug.Log("2 oldu");
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Grass"))
        {
            _soundNum = 0;
            Debug.Log("0 oldu");
        }

        else if (other.gameObject.CompareTag("Stone"))
        {
            _soundNum = 0;
            Debug.Log("0 oldu");
        }

    }


    void Step()
    {      
        switch (_soundNum)
        {
            case 1:
                _audioSource.PlayOneShot(_grassSound, _soundVolume);
                break;
            case 2:
                _audioSource.PlayOneShot(_stoneSound, _soundVolume);
                break;
        }
    }
}
