using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : IMove
{
    public float HorizontalAxis => Input.GetAxis("Horizontal") * Time.deltaTime;

    public float VerticalAxis => Input.GetAxis("Vertical") * Time.deltaTime;

    public float JumpAxis => Input.GetAxis("Jump");



    public void Horizontal (Transform _transform, float _horizontalSpeed, bool _isHorizontalActive)
    {
        switch (_isHorizontalActive)
        {
            case true:
                _transform.Rotate(Vector3.up * _horizontalSpeed * HorizontalAxis);
                break;
            default:
                _isHorizontalActive = false;
                break;
        }
    }


    public void Vertical (Transform _transform, float _verticalSpeed, bool _isVerticalActive)
    {
        switch (_isVerticalActive)
        {
            case true:
                _transform.Translate(Vector3.forward * _verticalSpeed * VerticalAxis);
                //_transform.position += new Vector3(0, 0, VerticalAxis* _verticalSpeed);
                break;
            default:
                _isVerticalActive = false;
                break;
        }
    }


    public void Jump(Rigidbody _rgdb, float _jumpForce, bool _isJumpActive)
    {
        switch (_isJumpActive)
        {
            case true:
                _rgdb.AddForce(Vector3.up * _jumpForce * JumpAxis);
                break;
            default:
                break;
        }
    }
}
