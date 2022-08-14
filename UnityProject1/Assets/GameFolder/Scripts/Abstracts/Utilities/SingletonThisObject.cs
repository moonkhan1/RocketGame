using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityProject1.Abstracts.Utilities
{
public abstract class SingletonThisObject<T> : MonoBehaviour
{
    public static T Instance { get; private set; }
    
        protected void SingletonThisGameObject(T entity)
        {
            if(Instance == null){
                // Buradaki ilk yaradilan GameManager obyektini buradaki THIS e menimsedirik
                Instance = entity;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                // Eger Eyni sehende bir GameObjectden birden cox yaradilmasina icaze vermesin
                Destroy(this.gameObject);
            }
        }
}
}