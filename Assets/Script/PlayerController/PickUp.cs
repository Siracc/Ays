using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{    
    [SerializeField] float _distance;
    void Update()
    {
        Vector3 _forward = transform.TransformDirection(Vector3.forward);
        RaycastHit hit;
        
        if (Physics.Raycast(transform.position, _forward, out hit))
        {
            Debug.DrawLine(transform.position, hit.point, Color.red);

            if (hit.distance <= _distance && hit.collider.gameObject.CompareTag("Red"))
            {                
                if (Input.GetKeyUp(KeyCode.E))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
