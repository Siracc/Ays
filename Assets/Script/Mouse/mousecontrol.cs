using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class mousecontrol : MonoBehaviour
{
    [SerializeField] float mouseSensitivy;

    [SerializeField] Transform _playerTransform;

    [SerializeField] GameObject _crosshair;
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Rotate();
            _crosshair.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(1))
        {

            _crosshair.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            //  Cursor.visible = false;
        }


    }

    private void FixedUpdate()
    {

        _crosshair.transform.position = Input.mousePosition;
        _crosshair.transform.position = new Vector3(_crosshair.transform.position.x + 15, _crosshair.transform.position.y - 24, 0);
    }
    private void Rotate()
    {

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivy * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivy * Time.deltaTime;


        // mouseY = Mathf.Clamp(mouseY, -5f, 5f);


        // transform.Rotate(Vector3.left, mouseY);
        _playerTransform.Rotate(Vector3.up, mouseX);

    }
}
