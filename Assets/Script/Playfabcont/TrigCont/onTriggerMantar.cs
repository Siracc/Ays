using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTriggerMantar : MonoBehaviour
{
    bool _toplama = false;
    public static bool _mantarToplama;

    private void OnTriggerEnter(Collider other)
    {
        _toplama = false;
    }


    private void OnTriggerStay(Collider col)
    {
        if (col.gameObject.CompareTag("PlayerBox"))
        {

          

            if (_toplama)
            {
                Destroy(gameObject.GetComponent<BoxCollider>());
                _mantarToplama = true;
                _toplama = false;
                Destroy(gameObject, 0.5f);

            }

        }
    }






    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            _toplama = true;
        }
    }
}
