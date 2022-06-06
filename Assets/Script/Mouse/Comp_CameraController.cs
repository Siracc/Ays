using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Comp_CameraController : MonoBehaviour
{
    [Header("Framing")]
    [SerializeField] Camera _camera ;
    [SerializeField] Transform _followTransform;
    [SerializeField] Transform _playerTransform;
    [SerializeField] Vector2 _framing = new Vector2(0, 0);


    [Header("Distance")]
    [SerializeField] float _zoomSpeed =10f;
    [SerializeField] float _defaultDistance = 5f;
    [SerializeField] float _minDistance = 0f;
    [SerializeField] float _maxDistance = 10f;


    [Header("Rotation")]
    [SerializeField] bool _invertX = false;
    [SerializeField] bool _invertY = false;
    [SerializeField] float _rotationSharpness = 25f;
    [SerializeField] float _deafultVerticalAngle = 20f;
    [SerializeField] [Range(-90,90)] float _minVerticalAngle = -90;
    [SerializeField] [Range(-90, 90)] private float _maxVerticalAngle = 90;

    [Header("Obstructions")]
    [SerializeField] float _checkRadius = 0.2f;
    [SerializeField] LayerMask _obstructionLayers = -1;
    List<Collider> _ignoreColliders = new List<Collider>();



    Vector3 _planarDirection;
    float _targetDistance;
    Vector3 _targetPosition;
    Quaternion _targetRotation;
    float _targetVerticalAngle;

    Vector3 _newPosition;
    Quaternion _newRotation;

    private void OnValidate()
    {
        _defaultDistance = Mathf.Clamp(_defaultDistance, _minDistance, _maxDistance);
        _deafultVerticalAngle = Mathf.Clamp(_deafultVerticalAngle, _minVerticalAngle, _maxVerticalAngle);
    }

    private void Start()
    {
        _ignoreColliders.AddRange(GetComponentsInChildren<Collider>());

        
        
        _planarDirection = _followTransform.forward;


        _targetDistance = _defaultDistance;
        _targetVerticalAngle = _deafultVerticalAngle;
        _targetRotation= Quaternion.LookRotation(_planarDirection) * Quaternion.Euler(_targetVerticalAngle, 0, 0);
        _targetPosition = _followTransform.position - (_targetRotation * Vector3.forward) * _targetDistance;


        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
       
        
        
        if (Cursor.lockState != CursorLockMode.Locked)
            return;

        float _zoom = Comp_PlayerInputs.MouseScrollInput *_zoomSpeed;
        float _mouseX = Comp_PlayerInputs.MouseXInput;
        float _mouseY = Comp_PlayerInputs.MouseYInput;

        if (_invertX) _mouseX *= -1f;
        if (_invertY) _mouseY *= -1f;

        Vector3 _focusPosition = _followTransform.position + new Vector3(_framing.x, _framing.y, 0);


        _playerTransform.Rotate(Vector3.up, _mouseX);

        _planarDirection = Quaternion.Euler(0, _mouseX, 0) * _planarDirection;
        _targetDistance = Mathf.Clamp(_targetDistance + _zoom, _minDistance, _maxDistance);
        if(Input.GetMouseButton(1))
        _targetVerticalAngle = Mathf.Clamp(_targetVerticalAngle + _mouseY, _minVerticalAngle, _maxVerticalAngle);

        Debug.DrawLine(_camera.transform.position, _camera.transform.position + _planarDirection, Color.red);


        float _smallestDistance = _targetDistance;
        RaycastHit[] _hits = Physics.SphereCastAll(_focusPosition, _checkRadius, _targetRotation * -Vector3.forward, _targetDistance, _obstructionLayers);
        if(_hits.Length!=0)
            foreach (RaycastHit hit in _hits)
            {
                if(!_ignoreColliders.Contains(hit.collider))
                {
                    if (hit.distance < _smallestDistance)
                        _smallestDistance = hit.distance;
                }
            }

        _targetPosition = _focusPosition - (_targetRotation * Vector3.forward) * _targetDistance;
        _targetRotation = Quaternion.LookRotation(_planarDirection)*Quaternion.Euler(_targetVerticalAngle,0,0);

        _newRotation = Quaternion.Slerp(_camera.transform.rotation, _targetRotation, Time.deltaTime * _rotationSharpness);
        _newPosition = Vector3.Lerp(_camera.transform.position, _targetPosition, Time.deltaTime * _rotationSharpness);

        _camera.transform.rotation = _newRotation;
        _camera.transform.position = _newPosition ;

    }
}

