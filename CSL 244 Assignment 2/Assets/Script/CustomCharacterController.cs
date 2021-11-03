using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CustomCharacterController : MonoBehaviour
{
    [Serializable]
    public struct CharType
    { 
        public string name;
        public GameObject gameObject;
    }
    
    private CharacterController _charCtrl;
    private Animator _animator;
    public float rotateSpeedHorizontal;
    
    public bool canJump = false;
    public bool canFall = false;
    public float jumpTime = 0.5f;
    public float jumpTimer = 0;

    public float fallingTime = 0.5f;
    public float fallingTimer = 0;
    
    private bool _correctValues=true;
    
    

    public CharType[] charTypes;
    public int currentCharValue;
    private int _maxCharValue;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private static readonly int IsRunning = Animator.StringToHash("IsRunning");
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");
    private static readonly int IsFalling = Animator.StringToHash("IsFalling");
    private static readonly int Landed = Animator.StringToHash("Landed");

    private void Start()
    {
        _charCtrl = charTypes[0].gameObject.GetComponent<CharacterController>();
        _animator = charTypes[0].gameObject.GetComponent<Animator>();
        _maxCharValue = charTypes.Length;
    }

    private void Update()
    {
        if (_correctValues)
        {
            _correctValues = SetParameters();
        }
        
        ChangeViewWithCamera();

        MoveWithAnimation();

    }
    


    #region - Animation -
    
    
    private void MoveWithAnimation()
    {
        ForHorizontalAnimation();
        ForVerticalAnimation();
    }

    private void ForHorizontalAnimation()
    {
        if (Input.GetKey(KeyCode.W))
        {
            _animator.SetBool(IsWalking,true);
        }
        else
        {
            _animator.SetBool(IsWalking,false);
        }
        
        if(Input.GetKey(KeyCode.LeftShift))
        {
            _animator.SetBool(IsRunning,true);
        }
        else
        {
            _animator.SetBool(IsRunning,false);
        }
    }

    private void ForVerticalAnimation()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump==false && canFall == false)
        {
            _animator.SetBool(IsJumping,true);
            canJump = true;
            jumpTimer = 0;
        }

        if (canJump)
        {
            jumpTimer += Time.deltaTime;
        }

        if (jumpTimer > jumpTime)
        {
            jumpTimer = 0;
            canJump = false;
            _animator.SetBool(IsJumping,false);
            _animator.SetBool(IsFalling,true);
            canFall = true;
            fallingTimer = 0;
        }

        if (canFall)
        {
            
            fallingTimer += Time.deltaTime;
        }

        if (fallingTimer > fallingTime)
        {
            fallingTimer = 0;
            _animator.SetBool(IsFalling,false);
            _animator.SetBool(Landed,true);
            canFall = false;
            canJump = false;
            
        }
    }

    
    #endregion

    private void ChangeViewWithCamera()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X")*rotateSpeedHorizontal, 0);
    }

    private bool SetParameters()
    {
        _charCtrl = charTypes[currentCharValue].gameObject.GetComponent<CharacterController>(); 
        _animator = charTypes[currentCharValue].gameObject.GetComponent<Animator>();
        return false;
    }
}
