using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator _animator;
    //private int _isWalkingHash;
    //private int _isRunningHash;
    private float _velocity = 0.0f;
    private int _velocityHash;
    private float _acceleration = 0.1f;
    private float _deceleration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        //_isWalkingHash = Animator.StringToHash("isWalking");
        //_isRunningHash = Animator.StringToHash("isRunning");
        _velocityHash = Animator.StringToHash("velocity");
    }

    // Update is called once per frame
    void Update()
    {
        //bool isWalking = _animator.GetBool(_isWalkingHash);
        //bool isRunning = _animator.GetBool(_isRunningHash);
        //bool forwardPressed = Input.GetKey("w");
        //bool runPressed = Input.GetKey("left shift") && forwardPressed;
        //if (isWalking != forwardPressed)
        //{
        //    _animator.SetBool(_isWalkingHash, forwardPressed);
        //}
        //if (isRunning != runPressed)
        //{
        //    _animator.SetBool(_isRunningHash, runPressed);
        //}    

        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        if (forwardPressed)
        {
            _velocity += Time.deltaTime * _acceleration;
        }
        else
        {
            _velocity -= Time.deltaTime * _deceleration;
        }
        _velocity = Mathf.Clamp(_velocity, 0, 1);
        _animator.SetFloat(_velocityHash, _velocity);
    }
}
