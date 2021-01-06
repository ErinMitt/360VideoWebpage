using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class videoChange : MonoBehaviour
{
    public UnityEngine.Video.VideoClip newVideo1;
    public UnityEngine.Video.VideoClip newVideo2;
    public UnityEngine.Video.VideoClip newVideo3;
    public UnityEngine.Video.VideoClip newVideo4;
    public UnityEngine.Video.VideoClip newVideo5;
    public GameObject ForwardButton;
    public GameObject BackButton;
    int currentVideo = 1;
    public GameObject text;


    public UnityEngine.Video.VideoAudioOutputMode audioOutputMode;

    public void ButtonForward()
    {
        var videoPlayer = gameObject.GetComponent<VideoPlayer>();

        if (currentVideo == 1)
        {
            videoPlayer.clip = newVideo2;
            text.SetActive(false);
            currentVideo = 2;
            BackButton.SetActive(true);
        }
        else if (currentVideo == 2)
        {
            videoPlayer.clip = newVideo3;
            currentVideo = 3;
        }
        else if (currentVideo == 3)
        {
            videoPlayer.clip = newVideo4;
            currentVideo = 4;
        }
        else if (currentVideo == 4)
        {
            videoPlayer.clip = newVideo5;
            currentVideo = 5;
            ForwardButton.SetActive(false);
        }
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
    }
    public void ButtonBackward()
    {
        var videoPlayer = gameObject.GetComponent<VideoPlayer>();

        if (currentVideo == 5)
        {
            videoPlayer.clip = newVideo4;
            currentVideo = 4;
            ForwardButton.SetActive(true);
        }
        else if (currentVideo == 4)
        {
            videoPlayer.clip = newVideo3;
            currentVideo = 3;
        }
        else if (currentVideo == 3)
        {
            videoPlayer.clip = newVideo2;
            currentVideo = 2;
        }
        else if (currentVideo == 2)
        {
            videoPlayer.clip = newVideo1;
            currentVideo = 1;
            BackButton.SetActive(false);
        }
        videoPlayer.renderMode = UnityEngine.Video.VideoRenderMode.MaterialOverride;
    }
}