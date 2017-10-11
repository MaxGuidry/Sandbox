using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour
{
    public int Speed = 1;
    
    public float TurnSpeed = 1f / 180f;
    public int MaxSpeed = 20;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && new Vector2(rb.velocity.x, rb.velocity.z).magnitude < MaxSpeed)
            rb.AddForce(this.transform.forward * Speed);
        else
        {
            Vector3 v = new Vector3(rb.velocity.x, 0, rb.velocity.z);
            rb.AddForce(-v.normalized * (v.magnitude/MaxSpeed));
            
        }
        if (Input.GetKey(KeyCode.D))
            this.transform.rotation *= new Quaternion(0, Mathf.Sin(TurnSpeed) / 2f, 0, Mathf.Cos(TurnSpeed) / 2f);
        if (Input.GetKey(KeyCode.A))
            this.transform.rotation *= new Quaternion(0, Mathf.Sin(-TurnSpeed) / 2f, 0, Mathf.Cos(-TurnSpeed) / 2f);

    }

    void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Water")
        {
            SimulateWater(other.transform);
            rb.useGravity = false;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Water")
        {
            SimulateWater(other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Water")
        {
            rb.useGravity = true;
        }
    }
    void SimulateWater(Transform t)
    {
        this.transform.position = new Vector3(this.transform.position.x, t.position.y + .5f + (this.transform.localScale.y / 2f - .2f), this.transform.position.z);
    }
}
// + t.gameObject.GetComponent<BoxCollider>().center.y