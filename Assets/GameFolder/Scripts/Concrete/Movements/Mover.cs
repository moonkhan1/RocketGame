using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UnityProject1.Movements{
public class Mover 
{
    Rigidbody _rigidBody;

    public Mover(Rigidbody _rigidBody)
    {
        _rigidBody = _rigidBody;
    }
    public void FixedTick()
    {
        _rigidBody.AddRelativeForce(Vector3.up * Time.deltaTime * 55f);
    }
}
}
