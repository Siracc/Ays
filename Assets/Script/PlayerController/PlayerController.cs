using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    MoveController _moveController;



    [SerializeField] Transform _playerTransform;
    [SerializeField] Rigidbody _playerRigidbody;
    [SerializeField] Animator _playerAnimator;
           
    [SerializeField] float _horSpeed, _verSpeed, _force;
    [SerializeField] bool _isHorizontalActive, _isVerticalActive, _isJumpActive;

    bool _isJump;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJump = true;
        }
        else 
            _isJump = false;
    }



    private void Awake()
    {
        _moveController = new MoveController();
    }


    private void FixedUpdate()
    {
        PlayerWalk();
        PlayerRotate();
        FastRun();
        Jump();
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

    void FastRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            _moveController.Vertical(_playerTransform, _verSpeed, _isVerticalActive);
            Debug.Log("Uieauiea");
            _playerAnimator.SetBool("__Fast", true);
        }
        else
            _playerAnimator.SetBool("__Fast", false);
    }
}
