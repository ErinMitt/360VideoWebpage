using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using System;
public class videoChange : MonoBehaviour
{
    public GameObject ForwardButton;
    public GameObject BackButton;
    public GameObject EnterButton;
    int currentVideo = 0;
    public GameObject text;
    public InputField mainInputField;
    string stringToSave = "";
    public List<string> videos = new List<string>();
    bool newClip=false;
    int clipNum = 0;
    public Text textlist;
    public GameObject videoOptions;
    public Dropdown deleteOptions;
    public GameObject delete;
    public GameObject[] charButtons;
    public Text[] videoNames;
    public void Start()
    {
       //textlist.text = PlayerPrefs.GetString(currentVideo.ToString());
    }
    public void VideoAssigned(){
        newClip = true;
    }
    public void OnGUI()
    {
        if (newClip==true)
        {
            videos.Add(mainInputField.text);
            //put in check to make sure clip name not too long for text box
           // string clipName = (clipNum + 1).ToString() + ". " + mainInputField.text;
            //List<string> m_DropOptions = new List<string> { clipName };
           // deleteOptions.AddOptions(m_DropOptions);
            string clipString = clipNum.ToString();
            stringToSave = mainInputField.text;
            PlayerPrefs.SetString(clipString, stringToSave);
            Debug.Log(stringToSave);
            PlayerPrefs.Save();
            newClip = false;
            Debug.Log(int.Parse(clipString));
            
            
             //  textlist.text += "\r\n" + mainInputField.text;
            if (clipNum != 0)
            {
                charButtons[clipNum-1] = (GameObject)Instantiate(delete);
                charButtons[clipNum-1].transform.SetParent(videoOptions.transform, false);
                charButtons[clipNum-1].transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 20+(clipNum*10), transform.localPosition.z + 30);
                delete = charButtons[clipNum - 1];
            }
            else{
                videoOptions.SetActive(true);

            }
            videoNames[clipNum] = (Text)Instantiate(textlist);
            videoNames[clipNum].transform.SetParent(videoOptions.transform, false);
            videoNames[clipNum].transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - 20, transform.localPosition.z + 30);
            videoNames[clipNum].text = stringToSave;
            textlist = videoNames[clipNum];
            clipNum++;
            if (currentVideo == clipNum-1)
            {
                ForwardButton.SetActive(true);
               
            }
        }
    }
    public UnityEngine.Video.VideoAudioOutputMode audioOutputMode;

    public void ButtonForward()
    {
        Debug.Log("forward");
     
            if(currentVideo==0){
            BackButton.SetActive(true);    
            }
        
        var videoPlayer = gameObject.GetComponent<VideoPlayer>();
            stringToSave = PlayerPrefs.GetString(currentVideo.ToString());
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, PlayerPrefs.GetString(currentVideo.ToString()));
            currentVideo++;
        if (currentVideo == clipNum)
        {
            ForwardButton.SetActive(false);
        }
        //make dissapear at max, appear if at max when adding new video
    }
    public void ButtonBackward()
    {
        if (currentVideo >0)
        {
            if (currentVideo == 1)
            {
                BackButton.SetActive(false);
            }

            var videoPlayer = gameObject.GetComponent<VideoPlayer>();
            stringToSave = PlayerPrefs.GetString(currentVideo.ToString());
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, stringToSave);
            currentVideo--;
            if (currentVideo == clipNum-1)
            {
                ForwardButton.SetActive(true);
            }
        }
        /*
        if (currentVideo<videos.Count){
        currentVideo--;
        var videoPlayer = gameObject.GetComponent<VideoPlayer>();
videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,videos[currentVideo]);
        }*/
    }
    public void DeleteButton()
    {
        int value = int.Parse(deleteOptions.options[deleteOptions.value].text.Substring(0, 1));
        //change to search for . to know length of substring
        Debug.Log(value);
        for (int i =value-1; i<clipNum; i++)
        {
            String stringToReplace = PlayerPrefs.GetString((i+1).ToString());
            PlayerPrefs.SetString(i.ToString(), stringToReplace);
            //not correct numbers
        }

    }
   public void ExitGame()
    {
        Application.Quit();
        Debug.Log("quit");
    }
}