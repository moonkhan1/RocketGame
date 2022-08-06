using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Movements;
using UnityProject1.Inputs;
using UnityProject1.Managers;

namespace UnityProject1.Controllers{
public class PlayerController : MonoBehaviour
{
    [SerializeField] float _turnSpeed = 10f;
    [SerializeField] float _force = 55f;
    
    // Rigidbody _rigidbody;
    DefaultInput _input;
    Mover _mover;
    Fuel _fuel;
    Rotater _rotater;
    
    bool _canMove;
    bool _canForceUp;
    float _leftRight;
    
    public float TurnSpeed => _turnSpeed;
    
    public float Force => _force;
    private void Awake() {
        // Rigidbodydeki propertiesleri class a otururuk
        // _rigidbody = GetComponent<Rigidbody>();
        _mover = new Mover(this);
        _input = new DefaultInput();
        _rotater = new Rotater(this);
        _fuel = GetComponent<Fuel>();
    }
    private void Start() {
        _canMove = true;
    }
    private void OnEnable() {
        GameManager.Instance.OnGameOver += HandleOnEventTriggered;
        GameManager.Instance.OnMissionSuccess += HandleOnEventTriggered;
    }
    private void OnDisable() {
        GameManager.Instance.OnGameOver -= HandleOnEventTriggered;
        GameManager.Instance.OnMissionSuccess -= HandleOnEventTriggered;
    }
    
    // update her bir frame de bir isleyir
    private void Update() {

        if(!_canMove) return; // Eger obyekt hereket ede bilmirse
        // Debug.Log(_force);
        //Input alir
        if (_input.IsForceUp && !_fuel.IsEmpty){
        _canForceUp = true;
        }
        else{
        _canForceUp = false;
        _fuel.FuelIncrease(0.01f);
        }
        _leftRight = _input.LeftRight;
    }

    // Fixed update ise her 0.02 saniyede bir calisir
    private void FixedUpdate() {
        // Fiziki isler(yerime, toqqusma)
        if(_canForceUp){
            // Debug.Log(Vector3.up * Time.deltaTime * _force);
            // Debug.Log(_rigidbody.AddForce(Vector3.up * Time.deltaTime * _force));
        _mover.FixedTick();
        _fuel.FuelDecrease(0.2f);

        }
        _rotater.FixedTick(_leftRight);
    }
    private void HandleOnEventTriggered()
    {
        _canForceUp=false;
        _canMove = false;
        _leftRight=0f;
        _fuel.FuelIncrease(0f);
    }
}
}
