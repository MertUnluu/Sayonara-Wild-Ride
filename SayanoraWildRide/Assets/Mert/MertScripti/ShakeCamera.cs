using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    public GameObject cam = null;
    public GameObject player = null;
    public bool IsShake = false;
    public bool IsShake2 = false;
    public bool IsPassage1 = false;
    public bool IsPassage2 = true;
    public bool IsPassage3 = false;

    private void Update()
    {
        if (IsShake)
        {
            Shaker();
            IsPassage2 = false;
        }
        if(IsShake2)
        {
            Shaker2();
        }
        if(IsPassage1)
        {
            ThePassage1();
            IsShake = false;
            IsPassage2 = false;
        }
        else if(IsPassage2)
        {
            ThePassage2();
            IsShake = false;
            IsPassage1 = false;
        }
        if(IsPassage3)
        {
            ThePassage3();
        }
    }

    public void Shaker()
    {
        //cam.transform.position = new Vector3(player.transform.position.x - 4, Random.Range(1.99f, 2.01f), Random.Range(-0.02f, 0.02f));
        cam.transform.position = new Vector3(player.transform.position.x - 4, Random.Range(1.99f, 2.01f), Random.Range(-0.02f, 0.02f));
    }

    public void Shaker2()
    {
        cam.transform.position = new Vector3(player.transform.position.x - 4, Random.Range(1.99f, 2.01f), -48);
    }

    void MakeShake()
    {
        IsShake = true;
        IsPassage2 = false;
    }

    void StopShake()
    {
        IsShake = false;
        IsPassage2 = true;
    }

    void ThePassage1()
    {
        cam.transform.position = new Vector3(player.transform.position.x - 4, player.transform.position.y - 2, player.transform.position.z);
        cam.transform.rotation = player.transform.rotation;
    }

    void ThePassage2()
    {
        cam.transform.position = new Vector3(player.transform.position.x - 4, player.transform.position.y + 2, player.transform.position.z);
        cam.transform.rotation = player.transform.rotation;
    }

    void ThePassage3()
    {
        cam.transform.position = new Vector3(player.transform.position.x + 4, player.transform.position.y + 2, player.transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ShakeTrigger")
        {
            IsShake = true;
            IsPassage1 = false;
            IsPassage2 = false;
        }
        if(other.gameObject.tag == "Passage")
        {
            IsShake = false;
            IsPassage2 = true;
            IsPassage1 = false;
            IsPassage2 = false;
        }
        if(other.gameObject.tag == "SideView")
        {
            IsShake2 = true;
        }
        if(other.gameObject.tag == "SideView2")
        {
            IsShake2 = false;
            IsPassage3 = true;
        }
    }
}
