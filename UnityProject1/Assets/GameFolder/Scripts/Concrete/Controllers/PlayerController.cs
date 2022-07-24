using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Movements;
using UnityProject1.Inputs;

namespace UnityProject1.Controllers{
public class PlayerController : MonoBehaviour
{
    // [SerializeField] float _force;
    // Rigidbody _rigidbody;
    DefaultInput _input;
    Mover _mover;
    bool _isForceUp;
    private void Awake() {
        // Rigidbodydeki propertiesleri class a otururuk
        // _rigidbody = GetComponent<Rigidbody>();
        _mover = new Mover (GetComponent<Rigidbody>());
        _input = new DefaultInput();
    }
    
    // update her bir frame de bir isleyir
    private void Update() {
        //Input alir
        if (_input.IsForceUp){
        _isForceUp = true;
        }
        else{
        _isForceUp = false;
        }
    }

    // Fixed update ise her 0.02 saniyede bir calisir
    private void FixedUpdate() {
        // Fiziki isler(yerime, toqqusma)
        if(_isForceUp){
        //     Debug.Log(Vector3.up * Time.deltaTime * _force);
        //     _rigidbody.AddForce(Vector3.up * Time.deltaTime * _force);
        _mover.FixedTick();

        }
    }
}
}
