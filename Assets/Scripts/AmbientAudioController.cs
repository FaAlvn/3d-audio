using UnityEngine;
using UnityEngine.InputSystem; // Using the new Input System you set up earlier

public class AmbientAudioController : MonoBehaviour
{
    // We will drag your Ambient Audio Source into this slot
    public AudioSource ambientMusic;

    void Update()
    {
        // Check if the keyboard is active and if the 'M' key was just pressed
        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            // Toggle the mute state on and off
            ambientMusic.mute = !ambientMusic.mute;
        }
    }
}