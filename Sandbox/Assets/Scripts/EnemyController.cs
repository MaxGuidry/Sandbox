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
            
            GameObject.Destroy(this.gameObject,5);
        }
        else
        {
            anim.SetTrigger("GetHit");
        }
    }
}





/*public GameObject player;
    public Text text;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Debug.DrawRay(player.transform.position + new Vector3(0,1,0), Camera.main.transform.forward, Color.black);
        if (Physics.SphereCast(player.transform.position + new Vector3(0,1,0), .5f, Camera.main.transform.forward, out hit, 5))
        {
            if (hit.transform == null)
                return;
            IInteractable iact = hit.transform.gameObject.GetComponent<IInteractable>();
            if (iact != null)
            { 
                text.text = "Press " + GameSettings.Interact.ToString() + " to " + iact.WhatDo + iact.Name;
                text.gameObject.SetActive(true);

            }
            else
            {
                text.gameObject.SetActive(false);
            }
        }
    }
*/