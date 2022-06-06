using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLife : MonoBehaviour
{
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _logSound;

    Rigidbody[] _childRg;
    
    [SerializeField] float _volume;
    [SerializeField] int _treeHealth;
    [SerializeField] bool _axActive;



    private void Awake()
    {
        _childRg = GetComponentsInChildren<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            _axActive = true;
            StartCoroutine(AxActive());
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ax"))
        {
            if (_axActive)
            {
                _audioSource.PlayOneShot(_logSound, _volume);
                _treeHealth--;
                Debug.Log("Çarptý");
                if (_treeHealth == 0)
                {
                    _audioSource.PlayOneShot(_logSound, _volume);
                    Rgidb();
                    StartCoroutine(TreeDestroy());
                    Debug.Log("Agac Silindi");
                }
            }                  
        }
    }

    IEnumerator AxActive()
    {
        yield return new WaitForSeconds(1.2f);
        _axActive = false;
    }

    IEnumerator TreeDestroy()
    {
        yield return new WaitForSeconds(1f);
        transform.DetachChildren();
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
    

    void Rgidb()
    {
        foreach (Rigidbody rg in _childRg)
        {
            rg.isKinematic = false;
        }
    }
}
