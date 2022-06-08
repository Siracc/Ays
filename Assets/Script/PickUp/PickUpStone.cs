using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpStone : MonoBehaviour
{
    [SerializeField] GameObject _eBas;
    


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBox"))
        {
            _eBas.SetActive(true);
            if (Input.GetKeyUp(KeyCode.E))
            {
                _eBas.SetActive(false);
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBox"))
            _eBas.SetActive(false);
    }
}
