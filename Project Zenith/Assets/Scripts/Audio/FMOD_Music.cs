using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FMOD_Music : MonoBehaviour
{
    FMOD.Studio.EventInstance BGM;
    // Start is called before the first frame update
    private void Start()
    {
        BGM = FMODUnity.RuntimeManager.CreateInstance("event:/Main BGM");
    }

    public void PlayBGM(){
        BGM.start();
    }

    public void PlaySong(string song){
        BGM.setParameterByName(song, 1f);
        //BGM.setParameterValue(song, 1f);
    }

    public void StopBGM(){
        BGM.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    private void OnDestroy(){
        BGM.release();
    }
}
