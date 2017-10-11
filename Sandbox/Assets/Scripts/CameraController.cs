using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    public float sensitivity = 1;
    private float deltaMouse = 0;
    private Vector3 mouse;
    private float y_offset;
    private Vector3 offsetVec;

    // Use this for initialization
    void Start()
    {
        mouse = Input.mousePosition;
        y_offset = this.transform.position.y - player.transform.position.y;
        offsetVec = this.transform.position - player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void LateUpdate()
    {
        deltaMouse = (Input.mousePosition - mouse).x;
        
        transform.RotateAround(player.transform.position, new Vector3(0, 1f, 0), deltaMouse * (sensitivity / 180f));


        this.transform.position = new Vector3(this.transform.position.x , y_offset + player.transform.position.y, this.transform.position.z );
        if ((this.transform.position - player.transform.position).magnitude != offsetVec.magnitude)
        {
            this.transform.position = ((this.transform.position - player.transform.position).normalized * offsetVec.magnitude) + player.transform.position;

        }
        transform.LookAt(player.transform.position + new Vector3(0, 2f, 0));
        mouse = Input.mousePosition;
    }
}