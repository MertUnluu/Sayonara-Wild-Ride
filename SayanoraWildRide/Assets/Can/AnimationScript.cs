using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Animator anim;
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("PlayJump", true);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            anim.SetBool("PlayJump", false);
        }

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trigger")
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            Time.timeScale = 0f;
        }

        if(other.gameObject.tag == "CamTrigger")
        {
            cam1.SetActive(false);
            cam2.SetActive(false);
            cam3.SetActive(true);
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    cam2.SetActive(false);
    //    cam1.SetActive(true);
    //}
}
