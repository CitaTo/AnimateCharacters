using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    private Animator _animator;
    private int _isWalkingHash;
    private int _isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _isWalkingHash = Animator.StringToHash("isWalking");
        _isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = _animator.GetBool(_isWalkingHash);
        bool isRunning = _animator.GetBool(_isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift") && forwardPressed;
        if (isWalking != forwardPressed)
        {
            _animator.SetBool(_isWalkingHash, forwardPressed);
        }
        if (isRunning != runPressed)
        {
            _animator.SetBool(_isRunningHash, runPressed);
        }    
        
    }
}
