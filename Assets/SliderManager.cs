using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    private float stageLength;
    public Transform player;
    public Slider progress;


    // Start is called before the first frame update
    void Start()
    {
        stageLength = DataBase.StageLength();
        progress.maxValue = stageLength;
        progress.minValue = 25;
    }

    // Update is called once per frame
    void Update()
    {
        progress.value = player.position.z;
    }
}
