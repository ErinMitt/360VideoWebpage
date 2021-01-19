using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class videoChange : MonoBehaviour
{
    public UnityEngine.Video.VideoClip newVideo1;
    public UnityEngine.Video.VideoClip newVideo2;
    public UnityEngine.Video.VideoClip newVideo3;
    public UnityEngine.Video.VideoClip newVideo4;
    public UnityEngine.Video.VideoClip newVideo5;
    public GameObject ForwardButton;
    public GameObject BackButton;
    public GameObject EnterButton;
    int currentVideo = -1;
    public GameObject text;
    public InputField mainInputField;
    public List<string> videos = new List<string>();

public void VideoAssigned(){
    videos.Add(mainInputField.text);
}
    public UnityEngine.Video.VideoAudioOutputMode audioOutputMode;

    public void ButtonForward()
    {
        if(currentVideo<videos.Count){
            if(currentVideo==0){
            BackButton.SetActive(true);    
            }
        currentVideo++;
        var videoPlayer = gameObject.GetComponent<VideoPlayer>();
videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,videos[currentVideo]);
        }
    }
    public void ButtonBackward()
    {
           if(currentVideo<videos.Count){
           /* if(currentVideo==0){
            BackButton.SetActive(true);    
            }*/
        currentVideo--;
        var videoPlayer = gameObject.GetComponent<VideoPlayer>();
videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,videos[currentVideo]);
        }
    }
}