using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// METRONOME SCRIPT: Controls animations and sound if first responder requests a metronome to keep tempo.

public class Metronome : MonoBehaviour
{
    // Public game objects for pulsing circle + text, and muted line objects
    public Image compressCircle;
    public Text compressText;
    public Image mutedLine;

    // Public object for AudioSource and Audioclip which plays sound effect
    public AudioSource metronomeSound;
    public AudioClip metronomeClip;

    // Private variable to prevent overlapping of pulse coroutine
    private bool pulsingNow;

    // Bool for mute. No sound plays if true
    private bool mute = true;

    // Start is called before the first frame update
    void Start()
    {
        pulsingNow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (pulsingNow == false)
        {
            StartCoroutine(PulseMetronome());
        }
    }

    // Function for unmute button
    public void Unmute()
    {
        // Invert the mute bool for toggle functionality
        mute = !mute;

        // If not muted, make the line which crosses out the volume symbol invisible
        if (mute == false)
        {
            mutedLine.CrossFadeAlpha(0, 0, false);
        }

        // If mute is on, make it visible again
        if (mute == true)
        {
            mutedLine.CrossFadeAlpha(1, 0, false);
        }
    }
    public void OnEnable()
    {
        pulsingNow = false;

        // If the user left it on unmute and came back to this menu, make the mute line invisible
        if (mute == false)
        {
            mutedLine.CrossFadeAlpha(0, 0, false);
        }
    }

    // Coroutine to pulse and time the metronome
    IEnumerator PulseMetronome()
    {
        // Set this to true so pulses don't overlap
        pulsingNow = true;

        // Make circle + text opaque
        compressCircle.CrossFadeAlpha(1, 0, true);
        compressText.CrossFadeAlpha(1, 0, true);

        // Play sound effect if mute is off
        if (mute == false)
        {
            metronomeSound.PlayOneShot(metronomeClip);
        }

        // Begin to fade out circle + text
        compressCircle.CrossFadeAlpha(0, 0.5f, true);
        compressText.CrossFadeAlpha(0, 0.5f, true);

        // Pause for 0.52 seconds: this is the gap between pulses to make around 100-110BPM
        yield return new WaitForSecondsRealtime(0.56f);

        // Set this to false again to allow pulse to repeat. This is the end of the cycle
        pulsingNow = false;
    }

}
