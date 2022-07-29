using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UnityProject1.Controllers{
public class StartFloorControllers : MonoBehaviour
{

    private void OnCollisionExit(Collision other)
    {
    PlayerController player = other.collider.GetComponent<PlayerController>();

    if(player != null)
    {
        Destroy(this.gameObject);
    }
    }
}

    
}