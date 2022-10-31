using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    [SerializeField] private AudioClip alarm;
    [SerializeField] private AudioClip bgm_Water;
    [SerializeField] private AudioClip bgm_Train;

    [SerializeField] private AudioClip[] listOfAudio;

    private float timer;
    private float Scenetimer;
    private bool canContinue1stScene;
    private bool voices;
    void Start()
    {
        //Plays the alarm at the start of the game
        SMScript.instance.PlayBGM(alarm);
        voices = false;
        timer = 5f;
        Scenetimer = 13f;
        FirstScene();
    }


    void Update()
    {
        timer -= Time.deltaTime;
        Scenetimer -= Time.deltaTime;

        if (timer <= 0)
        {
            SMScript.instance.PlayBGM(bgm_Water);
        }

        if (Scenetimer <=0 && canContinue1stScene) 
        {
            Debug.Log("I am here");
            if (Input.GetKeyDown(KeyCode.A))
            {
                SMScript.instance.PlayDialogue2(listOfAudio[11], 0);
                Debug.Log("Clicked");
                canContinue1stScene = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //scene switch
                canContinue1stScene = false;
            }
        
        }
    }

    void FirstScene()
    {
        SMScript.instance.PlayDialogue1(listOfAudio[3], 6);
        SMScript.instance.PlayDialogue2(listOfAudio[7], 10);
        canContinue1stScene=true;
    }
}
