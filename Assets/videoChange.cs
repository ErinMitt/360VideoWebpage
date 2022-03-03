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
    public GameObject EnterButton;
    public GameObject ClearButton;
    int currentVideo = -1;
    public GameObject text;
    public InputField mainInputField;
    string stringToSave = "";
    public List<string> videos = new List<string>();
    bool newClip=false;
    int clipNum = 0;
    public Text textlist;
    public GameObject videoOptions;
    public Dropdown deleteOptions;
    public Button delete;
    public Button clip;
    public Button[] clipNames;
    public VideoClip[] videoInputs;
    public Button[] charButtons;
    public Text[] videoNames;
    public void Start()
    {
        //add a check when a clip is added to check if the forward button needs to be visible
        while (PlayerPrefs.GetString(clipNum.ToString()) != "")
        {
            Debug.Log(PlayerPrefs.GetString(clipNum.ToString()));
            videoOptions.SetActive(true);
            clipNames[clipNum] = Instantiate(clip);
            clipNames[clipNum].name = clipNum + "clip";
            charButtons[clipNum] = Instantiate(delete);
            charButtons[clipNum].name = clipNum + "delete";
            clipNames[clipNum].transform.SetParent(videoOptions.transform, false);
            charButtons[clipNum].transform.SetParent(videoOptions.transform, false);
            clipNames[clipNum].transform.localPosition = new Vector3(transform.localPosition.x - 80, transform.localPosition.y + 60 - (clipNum * 20), transform.localPosition.z + 30);
            charButtons[clipNum].transform.localPosition = new Vector3(transform.localPosition.x + 20, transform.localPosition.y + 60 - (clipNum * 20), transform.localPosition.z + 30);
            clipNames[clipNum].GetComponentInChildren<Text>().text = PlayerPrefs.GetString(clipNum.ToString()) ;
            //clip = clipNames[clipNum];
           // delete = charButtons[clipNum];
            clipNum++;
        }
        //textlist.text = PlayerPrefs.GetString(currentVideo.ToString());
        Debug.Log(PlayerPrefs.GetString("0"));
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
            string clipString = clipNum.ToString();
            stringToSave = mainInputField.text;
            PlayerPrefs.SetString(clipString, stringToSave);
            Debug.Log(stringToSave);
            PlayerPrefs.Save();
            newClip = false;
            Debug.Log(int.Parse(clipString));

            videoOptions.SetActive(true);
            clipNames[clipNum] = Instantiate(clip);
            clipNames[clipNum].name = clipNum+  "clip";
            charButtons[clipNum] = Instantiate(delete);
            charButtons[clipNum].name = clipNum+ "delete";
            clipNames[clipNum].transform.SetParent(videoOptions.transform, false);
            charButtons[clipNum].transform.SetParent(videoOptions.transform, false);
            clipNames[clipNum].transform.localPosition = new Vector3(transform.localPosition.x-80, transform.localPosition.y + 60 - (clipNum * 20), transform.localPosition.z + 30);
            charButtons[clipNum].transform.localPosition = new Vector3(transform.localPosition.x+20, transform.localPosition.y +60-(clipNum*20), transform.localPosition.z + 30);
            clipNames[clipNum].GetComponentInChildren<Text>().text = stringToSave;
            clip = clipNames[clipNum];
            delete = charButtons[clipNum];
            

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

        Debug.Log("Button clicked");
        currentVideo++;
      //  if (PlayerPrefs.GetString(currentVideo.ToString()) != "") {
            
            if (currentVideo == 1)
            {
                BackButton.SetActive(true);
            }
            Debug.Log("hi" + currentVideo.ToString());
            var videoPlayer = gameObject.GetComponent<VideoPlayer>();
        //  stringToSave = PlayerPrefs.GetString(currentVideo.ToString());
        videoPlayer.clip=videoInputs[0];
   //     videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoNames[0].ToString());//PlayerPrefs.GetString(currentVideo.ToString()));
            if (currentVideo == clipNum-1)
            {
                ForwardButton.SetActive(false);
            }
       // }
     /*   else
        {
            currentVideo--;
        }*/
    }
    public void ButtonBackward()
    {
              if (currentVideo == 1)
               {
                   BackButton.SetActive(false);
               }
        currentVideo--;
        var videoPlayer = gameObject.GetComponent<VideoPlayer>();
        stringToSave = PlayerPrefs.GetString(currentVideo.ToString());
            videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, stringToSave);
            if (currentVideo != clipNum-1)
            {
                ForwardButton.SetActive(true);
            }
    }
    public void DeleteButton()
    {

        //  int value = int.Parse(deleteOptions.options[deleteOptions.value].text.Substring(0, 1));
        //change to search for . to know length of substring
        Debug.Log(EventSystem.current.currentSelectedGameObject.name);//charButtons[clipNum].name);
        int value = int.Parse(EventSystem.current.currentSelectedGameObject.name.Substring(0, 1));
        clipNames[value] = null;
        GameObject.Find(value + "clip").SetActive(false);
        GameObject.Find(value + "delete").SetActive(false);
        for (int x = value; x <= clipNum; x++)
        {
            if (x == clipNum)
            {
                //switch to delete 
                PlayerPrefs.DeleteKey(x.ToString());
                clipNum--;
            }

            PlayerPrefs.SetString(x.ToString(), PlayerPrefs.GetString((x+1).ToString()));
        }
        if (currentVideo == clipNum)
        {
            ForwardButton.SetActive(false);
        }
        if (currentVideo == 0)
        {
            BackButton.SetActive(false);
        }

    }
    public void ClearAll()
    {
        PlayerPrefs.DeleteAll();
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}