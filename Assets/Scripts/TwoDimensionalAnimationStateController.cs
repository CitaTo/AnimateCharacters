using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoDimensionalAnimationStateController : MonoBehaviour
{
    private Animator _animator;
    private float _velocityZ = 0.0f;
    private float _velocityX = 0.0f;
    private int _velocityZHash;
    private int _velocityXHash;

    private float _acceleration = 2.0f;
    private float _deceleration = 2.0f;

    private float _maxWalkVelocity = 0.5f;
    private float _maxRunVelocity = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _velocityZHash = Animator.StringToHash("velocityZ");
        _velocityXHash = Animator.StringToHash("velocityX");
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool leftPressed = Input.GetKey("a");
        bool rightPressed = Input.GetKey("d");
        bool runPressed = Input.GetKey("left shift");

        float currentMaxVelocity = runPressed ? _maxRunVelocity : _maxWalkVelocity;

        ChangeVelocity(forwardPressed, leftPressed, rightPressed, currentMaxVelocity);

        _animator.SetFloat(_velocityZHash, _velocityZ);
        _animator.SetFloat(_velocityXHash, _velocityX);
    }

    private void ChangeVelocity(bool forwardPressed, bool leftPressed, bool rightPressed, float currentMaxVelocity)
    {
        if (forwardPressed)
        {
            _velocityZ += Time.deltaTime * _acceleration;
            if (_velocityZ > currentMaxVelocity)
            {
                _velocityZ = currentMaxVelocity;
            }
        }
        else
        {
            _velocityZ -= Time.deltaTime * _deceleration;
            if (_velocityZ < 0.0f)
            {
                _velocityZ = 0.0f;
            }
        }

        if (leftPressed || rightPressed)
        {
            if (leftPressed)
            {
                _velocityX += Time.deltaTime * _acceleration;
                if (_velocityX > currentMaxVelocity)
                {
                    _velocityX = currentMaxVelocity;
                }
            }
            if (rightPressed)
            {
                _velocityX -= Time.deltaTime * _deceleration;
                if (_velocityX < -currentMaxVelocity)
                {
                    _velocityX = -currentMaxVelocity;
                }
            }
        }
        else
        {
            if (_velocityX > 0)
            {
                _velocityX -= Time.deltaTime * _deceleration;
            }
            if (_velocityX < 0)
            {
                _velocityX += Time.deltaTime * _deceleration;
            }
        }
    }
}
