using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Нужна для работы с интерфейсом

public class BulletController : MonoBehaviour {
    
    public int ammo;
    public int ammoCount;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag =="Ammo")
        {
            ammoCount += ammo;
            Destroy(other.gameObject);
        }
    }
}
