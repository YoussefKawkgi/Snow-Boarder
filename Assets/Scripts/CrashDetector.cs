using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] float crashDelay = 0.5f;
    [SerializeField] ParticleSystem crashEffect;
    [SerializeField] AudioClip CrashSFX;
    bool hasCrashed = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ground" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            crashEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(CrashSFX);
            Invoke("ReloadScene", crashDelay);
        }    
    }
        void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

}

