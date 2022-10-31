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
    private float scene1Timer;
    private float scene2Timer;
    private bool canContinue1stScene;
    private bool voices;
    void Start()
    {
        //Plays the alarm at the start of the game
        SMScript.instance.PlayBGM(alarm);
        voices = false;
        timer = 5f;
        scene1Timer = 16f;
        scene2Timer = 16f;
        FirstScene();
    }


    void Update()
    {
        timer -= Time.deltaTime;
        scene1Timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SMScript.instance.PlayBGM(bgm_Water);
        }

        if (scene1Timer <=0 && canContinue1stScene) 
        {
            //Debug.Log("I am here");
            if (Input.GetKeyDown(KeyCode.A))
            {
                SMScript.instance.PlayDialogue2(listOfAudio[11], 0);
                SecondScene();
                canContinue1stScene = false;
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                //scene switch
                SecondScene();
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

    void SecondScene()
    {
        SMScript.instance.StopBGM();
        SMScript.instance.PlayBGM(bgm_Train);
        
    }
}
