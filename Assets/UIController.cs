using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Networking;

public class UIController : MonoBehaviour
{
    string path;
    public AudioClip audio;
    public Button fileExplorer;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        fileExplorer.onClick.AddListener(GetSong);    
    }

    void GetSong()
    {
        path = EditorUtility.OpenFilePanel("Choose audio file", "", "mp3");

        if (path != null)
        {
            UpdateSong();
        }
    }

    void UpdateSong()
    {
        Debug.Log("Update");

         using (var uwr = UnityWebRequestMultimedia.GetAudioClip("file://" + path, AudioType.AUDIOQUEUE))
            {
                ((DownloadHandlerAudioClip)uwr.downloadHandler).streamAudio = true;

 
                DownloadHandlerAudioClip dlHandler = (DownloadHandlerAudioClip)uwr.downloadHandler;
 
                if (dlHandler.isDone)
                {
                    AudioClip audioClip = dlHandler.audioClip;
 
                    if (audioClip != null)
                    {
                        AudioSource player = (AudioSource)GetComponent(typeof(AudioSource));
                        player.clip = audioClip;

                        player.Play();
 
                        Debug.Log("Playing song using Audio Source!");
                       
                    }
                    else
                    {
                        Debug.Log("Couldn't find a valid AudioClip :(");
                    }
                }
                else
                {
                    Debug.Log("The download process is not completely finished.");
                }
            }
    }
}
