using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.Playables;

public class DemonBehavior : MonoBehaviour
{
    public Camera renderingcam;
    public CinemachineVirtualCamera trackcam;

    private float camtime;
    private Animator anim;
    // Use this for initialization
    void Start()
    {
        renderingcam.gameObject.SetActive(true);
        PlayableDirector pd = trackcam.GetComponent<PlayableDirector>();
        pd.enabled = true;
        camtime = (float)pd.duration + 1;
        anim = GetComponent<Animator>();

    }

    private float timepassed = 0;
    // Update is called once per frame
    void Update()
    {
        if (timepassed > -1)
        {
            if (timepassed < camtime + 1.5f)
                timepassed += Time.deltaTime;
            else
            {
                timepassed = -5;
            }

            if (timepassed > camtime - 2 && timepassed < camtime - 1.9f)
                Rage();
            if (timepassed > camtime + 1.5f)
                DisableDemonCam();
        }
    }

    public void DisableDemonCam()
    {
        renderingcam.gameObject.SetActive(false);
        trackcam.GetComponent<PlayableDirector>().enabled = false;
    }
    public void Rage()
    {
        anim.SetTrigger("Rage");
    }
}
