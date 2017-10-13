using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
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
    [HideInInspector]
    public static bool InBoat;
    private Transform mine;

    public Player player;
    // Use this for initialization
    void Start()
    {
        player = ScriptableObject.CreateInstance<Player>();
        player.health = 10;
        player.damage = 10;
        rb = GetComponent<Rigidbody>();
        position = this.transform.position;
        anim = GetComponent<Animator>();
        acceleration = new Vector3(Camera.main.transform.forward.x, 0, Camera.main.transform.forward.z);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.B))
        {
            if (InBoat)
            {

                this.transform.position = this.transform.position + this.transform.right;
                rb.useGravity = true;
            }

            else
            {
                mine = FindObjectOfType<BoatControl>().gameObject.transform;
                this.transform.position = mine.position;
                rb.useGravity = false;
            }

            InBoat = !InBoat;
        }
        if (!InBoat)
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
            Quaternion q = this.transform.rotation;

            this.transform.LookAt(this.transform.position + velocity);
            this.transform.rotation = Quaternion.Slerp(q, this.transform.rotation, .2f);
            if (Input.GetKeyDown(GameSettings.Jump))
                Jump();
            if (Input.GetKeyDown(GameSettings.Attack))
                Attack();
        }
        else
        {
            this.transform.position = mine.position;
            this.transform.rotation = mine.transform.rotation;
        }
        

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
        if (Vector3.Dot(rb.velocity.normalized, new Vector3(0, -1, 0)) > .3f)
            this.transform.position = new Vector3(position.x, t.position.y, position.z);
    }
    void Attack()
    {
        anim.SetTrigger("attack");
       
    }

    public void TryToHit()
    {
        RaycastHit hit;
        Physics.Raycast(new Ray(this.transform.position + new Vector3(0, 1, 0), this.transform.forward), out hit, 10);

        if (hit.transform == null)
            return;
        EnemyController ec = hit.transform.gameObject.GetComponent<EnemyController>();
        if (ec != null)
        {
            
            player.DoDamage(ec.enemy);
            ec.GetHit();
        }
    }
    void Jump()
    {
        anim.SetTrigger("Jump");
        //anim.speed = 5f/JumpHeight;
        rb.AddForce(Vector3.up * JumpHeight, ForceMode.Impulse);
    }
    
}
//+ (this.transform.localScale.y / 2f - 1f) + position.y