using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lauchmodes : MonoBehaviour
{
   public GameObject EditModeScene;
   public GameObject ViewModeScene;
    public GameObject IntroModeScene;
    public void EditMode()
    {
        EditModeScene.SetActive(true);
        IntroModeScene.SetActive(false);
    }
    public void ViewMode()
    {
        ViewModeScene.SetActive(true);
        IntroModeScene.SetActive(false);
    }
}
