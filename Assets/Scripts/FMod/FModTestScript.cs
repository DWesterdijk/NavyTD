using UnityEngine;

/// <summary>
/// This is a test script and can be used as reference when making the other FMOD related scripts.
/// </summary>
public class FModTestScript : MonoBehaviour
{
    public int parameter;

    //Create Event Instances
    FMOD.Studio.EventInstance _playSoundOnEnter;
    FMOD.Studio.EventInstance _playSoundOnExit;
    FMOD.Studio.EventInstance _music;

    private void Awake()
    {
        parameter = 0;

        //Get the corrosponding Events
        _playSoundOnEnter = FMODUnity.RuntimeManager.CreateInstance("event:/HasEntered");
        _playSoundOnExit = FMODUnity.RuntimeManager.CreateInstance("event:/HasLeft");
        _music = FMODUnity.RuntimeManager.CreateInstance("event:/ParameterEvent");

        //Start music
        _music.start();
    }

    private void Update()
    {
        _music.setParameterByName("TestParam", parameter);
    }

    //On Trigger Enter, play the sound
    private void OnTriggerEnter(Collider other)
    {
        _playSoundOnEnter.start();
    }

    //On Trigger Exit, play the sound
    private void OnTriggerExit(Collider other)
    {
        _playSoundOnExit.start();
    }
}
