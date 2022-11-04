using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public float score = 0;
    public static Score _instance;
    void Awake()
    {
        _instance = this;
    }

    //this script is attached to canvas
    //subSpeed is the the speed npc score decreases
    public int subSpeed;
    //minimum score for npc to start action
    public int npcRunScore;
    //when npcscore drops to backscore, npc will return
    public int npcBackScore;
    //dont modify this param
    public float npcScore;

    void Update()
    {
        scoreText.text = "Score: " + score.ToString("0");
        if (npcScore > 0)
        {
            //npc score gradually decrease since it come out
            npcScore -= Time.deltaTime*subSpeed;
            
        }
    }
}
