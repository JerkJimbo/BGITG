using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healthenemy : MonoBehaviour {

    public int hp = 1;
    public bool isEnemy = true;
	// Use this for initialization
	public void Damage(int damageCount)
    {
        hp -= damageCount;
        if(hp<=0)
        {
            Destroy(gameObject);
        }
                
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Bullet2D shot = otherCollider.gameObject.GetComponent<Bullet2D>();
        if(shot!=null)
        {
            if(shot.isEnemyShot!=isEnemy)
            {
                Damage(shot.damage);
                Destroy(shot.gameObject);
            }
        }
    }
    
}
