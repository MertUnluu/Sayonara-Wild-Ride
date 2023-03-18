using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TriggerChange : MonoBehaviour
{
    public ShakeCamera SC = null;
    public GameObject Enemies = null;
    public GameObject Enemies2 = null;
    public GameObject Crosshair = null;
    public GameObject Cam = null;
    public GameObject OriginalPos = null;
    public Transform Side = null;
    public Animator flip;
    public GameObject Flipper = null;
    public GameObject Oturtma = null;
    public PlayableDirector playMe = null;
    public Animator hower = null;
    public PlayableDirector Ending = null;
    public Animator FirstEnemy = null;
    public Animator TheFinish = null;
    public Animator TheEnd = null;
    public GameObject Theend = null;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Passage1")
        {
            Oturtma.SetActive(false);
            SoundManager.instance.PlaySoundEffect(1, other.transform.position, 1.0f, 0.1f);
            Flipper.SetActive(true);
            flip.SetBool("IsJumping", true);
            //SC.IsPassage1 = true;
            //SC.IsPassage2 = false;
        }
        if(other.gameObject.tag == "Passage2")
        {
            Oturtma.SetActive(false);
            SoundManager.instance.PlaySoundEffect(1, other.transform.position, 1.0f, 0.1f);
            Flipper.SetActive(true);
            flip.SetBool("IsJumping", true);
            //SC.IsPassage2 = true;
            //SC.IsPassage1 = false;
        }
        if(other.gameObject.tag == "Stopper")
        {
            flip.SetBool("IsJumping", false);
            Flipper.SetActive(false);
            Oturtma.SetActive(true);
        }

        if(other.gameObject.tag == "Cutscene")
        {
            playMe.Play();
            SoundManager.instance.PlaySoundEffect(2, Enemies.transform.position, 1.0f, 0.1f);
            //thenemies.Play();
            Enemies.SetActive(true);

        }
        if(other.gameObject.tag == "ShootTime")
        {
            Crosshair.SetActive(true);
            hower.SetBool("IsCutscene", true);
            //thenemies.Stop();
            //Enemies.SetActive(true);
        }

        if(other.gameObject.tag == "SideView")
        {
            Cam.transform.position = Vector3.Lerp(Cam.transform.position, Side.transform.position, 5);
            SoundManager.instance.PlaySoundEffect(3, Enemies2.transform.position, 1.0f, 0.1f);
            Cam.transform.rotation = Quaternion.Euler(0, 0, 0);
            Enemies2.SetActive(true);
        }
        if(other.gameObject.tag == "SideView2")
        {
            Cam.transform.position = new Vector3(OriginalPos.transform.position.x + 4, OriginalPos.transform.position.y + 2, OriginalPos.transform.position.z);
            Cam.transform.rotation = Quaternion.Euler(0, -90, 0);
            Crosshair.SetActive(false);
            Ending.Play();
        }
        if(other.gameObject.tag == "Finish")
        {
            TheFinish.SetBool("IsFinished", true);
        }
        if(other.gameObject.tag == "Ending")
        {
            Theend.SetActive(true);
            SoundManager.instance.PlaySoundEffect(6, transform.position, 1.0f, 0.1f);
            TheEnd.SetBool("IsEnd", true);
            this.gameObject.SetActive(false);
            Invoke("NextSceneGo", 5);
        }
    }

    void NextSceneGo()
    {
        SceneManager.LoadScene("MertFinal");
    }
}
