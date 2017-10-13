using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Enemy enemy;

    public Animator anim;
	// Use this for initialization
	void Start ()
	{
	    anim = GetComponent<Animator>();
	    enemy = ScriptableObject.CreateInstance<Enemy>();
	    enemy.health = 50;
	    enemy.damage = 10;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GetHit()
    {
        
        if (enemy.health <= 0)
        {
            enemy.health = 0;
            anim.SetTrigger("Die");
            
            GameObject.Destroy(this.gameObject,1);
        }
        else
        {
            anim.SetTrigger("GetHit");
        }
    }
}
