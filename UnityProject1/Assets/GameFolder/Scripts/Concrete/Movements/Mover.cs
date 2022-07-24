using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityProject1.Controllers;


namespace UnityProject1.Movements{
public class Mover 
{
    Rigidbody _rigidBody;
    PlayerController _playerController;
    public Mover(PlayerController playerController)
    {
        _playerController = playerController;
        _rigidBody = playerController.GetComponent<Rigidbody>();
    }
    public void FixedTick()
    {
        _rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * _playerController.Force);
    }
}
}
