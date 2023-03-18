using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PathCreation.Examples;
using PathCreation;

public class Player : MonoBehaviour
{
    public Text scoreLabel;
    int score;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin")){
            score++;
            scoreLabel.text = "Score: "+score.ToString();
            SoundManager.instance.PlaySoundEffect(0, other.transform.position, 1.0f, 0.1f);
            other.GetComponent<Animator>().Play("coin_take");
            Destroy(other.gameObject,1.0f);
           
        }
        else if (other.CompareTag("PathChanger"))
        {
            Debug.Log("ah");
            PathCreator _nextpath = other.GetComponent<PathChanger>().nextPath;
            PathFollower.instance.ChangePath(_nextpath);
        }

        else if(other.gameObject.tag == "Obstacle")
        {
            GameObject.FindGameObjectWithTag("MainCamera").transform.parent = null;
            gameObject.SetActive(false);
        }
    }
}
