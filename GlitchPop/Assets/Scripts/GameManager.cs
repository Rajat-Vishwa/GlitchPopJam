using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using URPGlitch.Runtime.AnalogGlitch;
using URPGlitch.Runtime.DigitalGlitch;

public class GameManager : MonoBehaviour
{   

    public bool glitch;
    public bool analogGlitch;
    public bool digitalGlitch;
    public VolumeProfile volume;
    void Start()
    {
        volume = gameObject.GetComponent<Volume>().profile;
    }

    void Update()
    {
        Glitch();
    }

    void Glitch(){
        AnalogGlitchVolume analogVol;
        DigitalGlitchVolume digitalVol;

        if(volume.TryGet<AnalogGlitchVolume>(out analogVol)){
            if(analogGlitch){
                if(glitch) analogVol.active = true;
                else analogVol.active = false;
            }
        }

        if(volume.TryGet<DigitalGlitchVolume>(out digitalVol)){
            if(digitalGlitch){
                if(glitch) digitalVol.active = true;
                else digitalVol.active = false;
            }
        }
    }
}
