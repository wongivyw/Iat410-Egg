using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseLevelSustain : MonoBehaviour
{   
    public GameObject terrain; 
    public NoiseLevel nl;
    public float timer;
    //time interval between each decrease
    [SerializeField] public float interval = 5f;
    // the noise level decrease by nlDecreasedCount
    [SerializeField] public int nlDecreasedCount = 2;
    //minimum noise level to allow the value change. nlMinimum must be greater or equal to nlDecreasedCount to avoid negative value
    [SerializeField] public int nlMinimum = 2;
    
   

    void Start() 
    {
        terrain = GameObject.Find("Terrain");
        nl = terrain.GetComponent<NoiseLevel>();
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer > interval && nl.noiseLevel >= nlMinimum){
            nl.noiseLevel -= nlDecreasedCount;
            Debug.Log("Noise Level Decreases! Current Noise Level: " + nl.noiseLevel);
            //reset timer
            timer = 0;
        }
    }
}
