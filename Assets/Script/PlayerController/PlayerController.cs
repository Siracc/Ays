using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MoveController _moveController;

    [SerializeField] Transform _playerTransform;
    [SerializeField] Rigidbody _playerRigidbody;
    [SerializeField] Animator _playerAnimator;
           
    [SerializeField] float _horSpeed, _verSpeed, _force, _fastRun;
    [SerializeField] float mouseSensitivy;
    [SerializeField] bool _isHorizontalActive, _isVerticalActive, _isJumpActive, _isFastActive;

    bool _isJump;

    private void Awake()
    {
        _moveController = new MoveController();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJump = true;
        }
        else 
            _isJump = false;
    }

    private void FixedUpdate()
    {
        PlayerWalk();
        PlayerRotate();
        Jump();
        Ax();
    }

    void PlayerWalk()
    {
        _moveController.Vertical(_playerTransform, _verSpeed, _isVerticalActive);          
        _playerAnimator.SetFloat("__Walk", Mathf.Abs(Input.GetAxis("Vertical")));
    }

    void PlayerRotate()
    {
        _moveController.Horizontal(_playerTransform, _horSpeed, _isHorizontalActive);
    }


    void Jump()
    {
        if (_isJump)
        {
            _moveController.Jump(_playerRigidbody, _force, _isJumpActive);
            _playerAnimator.SetBool("__Jump", true);
        }
        else 
            _playerAnimator.SetBool("__Jump", false);
    }

    void Ax()
    {
        if (Input.GetMouseButton(0))
        {
            //_isVerticalActive = false;
            _playerAnimator.SetBool("__Ax", true);
            //StartCoroutine(IsVertical());
        }
        else
            _playerAnimator.SetBool("__Ax", false);
    }   

    IEnumerator IsVertical()
    {
        yield return new WaitForSeconds(2.3f);
        _isVerticalActive = true;
    }
}
