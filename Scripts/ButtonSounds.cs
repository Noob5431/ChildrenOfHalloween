using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonSounds : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip onMouseOverSound;
    AudioSource source;
    private void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
    }

    public void OnPointerEnter(PointerEventData data)
    {
        source.Stop();
        source.PlayOneShot(onMouseOverSound);  
    }
}
