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

    public float maxDuration = 5f, minDuration = 1f;
    public float maxGap = 20f, minGap = 5f;
    public float gapTimer, durTimer;
    public GameObject player;
    void Start()
    {
        volume = gameObject.GetComponent<Volume>().profile;
        player = GameObject.FindGameObjectWithTag("Player");
        GenerateEvent();
    }

    void Update()
    {
        if(gapTimer <= 0){
            if(durTimer <= 0){
                glitch = false;
                player.GetComponent<CharacterManager>().ChangeCharacter();
                GenerateEvent();
            }else{
                glitch = true;
                durTimer -= Time.deltaTime;
            }
        }else gapTimer -= Time.deltaTime;

        Glitch();
        
    }
    
    void GenerateEvent(){
        float gap = Random.Range(minGap, maxGap);
        float dur = Random.Range(minDuration, maxDuration);
        durTimer = dur;
        gapTimer = gap;
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
