using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float WalkSpeed = 1;
    public float RunSpeed = 2;
    public float JumpHeight = 5;
    private Vector3 acceleration = Vector3.zero;
    private Vector3 velocity = Vector3.zero;
    private Vector3 position;
    private Rigidbody rb;
    private Animator anim;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        position = this.transform.position;
        anim = GetComponent<Animator>();
        acceleration = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);

    }

    // Update is called once per frame
    void Update()
    {
        position = this.transform.position;
        acceleration = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);
        acceleration *= 20;
        float Speed = (Input.GetKey(KeyCode.LeftAlt)) ? RunSpeed : WalkSpeed;
        if (Input.GetKey(KeyCode.W) && velocity.magnitude < Speed)
        {
            velocity = acceleration.normalized * velocity.magnitude;

            velocity += acceleration * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            velocity += acceleration * Time.deltaTime;
            velocity = velocity.normalized * Speed;

        }
        else
        {
            Vector3 v = new Vector3(velocity.x, 0, velocity.z);
            velocity += -velocity * ((v.magnitude * 25f) / WalkSpeed) * Time.deltaTime;

        }

        position += velocity * Time.deltaTime;
        anim.SetFloat("velocity", velocity.magnitude);
        this.transform.position = position;
        this.transform.LookAt(this.transform.position + velocity);
        if (Input.GetKeyDown(GameSettings.Jump))
            Jump();
        if (Input.GetKeyDown(GameSettings.Attack))
            Attack();
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

        this.transform.position = new Vector3(rb.position.x, t.position.y + (this.transform.localScale.y / 2f - 1f), rb.position.z);

    }
    bool Attack()
    {
        anim.SetTrigger("attack");
        return false;
    }
    void Jump()
    {
        anim.SetTrigger("Jump");
        rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
    }
}
