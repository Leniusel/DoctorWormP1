using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{
    public ParticleSystem psRain;

    // Update is called once per frame
    void Update()
    {
        var main = psRain.main;
        main.simulationSpeed = 10;
    }
}