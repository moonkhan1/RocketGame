using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Movements;
using UnityProject1.Inputs;

namespace UnityProject1.Controllers{
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 10f;
    [SerializeField] float _force = 55f;
    // Rigidbody _rigidbody;
    DefaultInput _input;
    Mover _mover;

    Rotater _rotater;
    bool _isForceUp;
    float _leftRight;
    public float TurnSpeed => _turnSpeed;
    public float Force => _force;
    private void Awake() {
        // Rigidbodydeki propertiesleri class a otururuk
        // _rigidbody = GetComponent<Rigidbody>();
        _mover = new Mover(this);
        _input = new DefaultInput();
        _rotater = new Rotater(this);
    }
    
    // update her bir frame de bir isleyir
    private void Update() {
        Debug.Log(_input.LeftRight);
        //Input alir
        if (_input.IsForceUp){
        _isForceUp = true;
        }
        else{
        _isForceUp = false;
        }
        _leftRight = _input.LeftRight;
    }

    // Fixed update ise her 0.02 saniyede bir calisir
    private void FixedUpdate() {
        // Fiziki isler(yerime, toqqusma)
        if(_isForceUp){
        //     Debug.Log(Vector3.up * Time.deltaTime * _force);
        //     _rigidbody.AddForce(Vector3.up * Time.deltaTime * _force);
        _mover.FixedTick();

        }
        _rotater.FixedTick(_leftRight);
    }
}
}
