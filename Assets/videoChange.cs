using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class videoChange : MonoBehaviour
{
    public GameObject ForwardButton;
    public GameObject BackButton;
    int currentVideo = -1;
   
    public VideoClip[] videoInputs;
    int size;
    //public Button[] charButtons;
    public void Start()
    {
         size = videoInputs.Length;
    }


    
    public void ButtonForward()
    {
        currentVideo++;
        if (currentVideo<size) {
            
            if (currentVideo == 1)
            {
                BackButton.SetActive(true);
            }
            var videoPlayer = gameObject.GetComponent<VideoPlayer>();
        videoPlayer.clip=videoInputs[currentVideo];
        }
       else
        {

            Debug.Log("else triggered");
            currentVideo--;
        }
    }
    public void ButtonBackward()
    {
        currentVideo--;
        if (currentVideo >= 0)
        {
            var videoPlayer = gameObject.GetComponent<VideoPlayer>();
            videoPlayer.clip =videoInputs[currentVideo];
            if (currentVideo == 0)
            {
            //    BackButton.SetActive(false);
            }

            if (currentVideo == size - 2)
            {
                ForwardButton.SetActive(true);
            }
            if (currentVideo == size - 1)
            {
           //     ForwardButton.SetActive(false);
            }

        }
        else
        {
            Debug.Log("else triggered");
            currentVideo++;
        }
     
    }
 
    public void ExitGame()
    {
        Application.Quit();
    }
}