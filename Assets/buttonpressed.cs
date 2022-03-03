using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using Valve.VR;
using System;

public class buttonpressed : MonoBehaviour
{
    public InputActionReference inputReference;
    public GameObject model;
    [SerializeField]
    //  InputActionProperty m_ActionReference;
    //  public SteamVR_Action_Pose poseAction = SteamVR_Input.GetAction<SteamVR_Action_Pose>("GrabGrip");
    // SteamVR_TrackedController controller = GetComponent();
    //GameObject trigger;
    void Awake()
    {
        Debug.Log("2");
        inputReference.action.started += Attached;
        inputReference.action.canceled += Detached;
    }

    private void Detached(InputAction.CallbackContext obj)
    {
        throw new NotImplementedException();
    }

    private void Attached(InputAction.CallbackContext obj)
    {
        /*if (GetComponent<XRGrabInteractable>().isSelected)
        {
            Debug.Log("true");
        }*/
       // Debug.Log("false");
    }

    // public InputActionProperty actionReference; // { get => m_ActionReference; set => m_ActionReference = value; }
    [Obsolete]
    void Start()
    {
    //    Debug.Log(model.transform.Find("Trigger").gameObject);
        /*
      if(model.transform.Find("Trigger").gameObject)
        {
            Debug.Log("true");
        }
        else
        {
            Debug.Log("false");
        }
        */
            
            transform.Find("model/Trigger");
        //  controller.TriggerClicked += printMessage;
        Debug.Log("hi");
    }
    /*    public bool GetState(SteamVR_Input_Sources inputSource)
          {
              return sourceMap[inputSource].state;
          }*/
    // Update is called once per frame
    void Update()
    {
       /* if (GetComponent<XRGrabInteractable>().isSelected)
        {
            Debug.Log("true");
        }
        Debug.Log("false");*/
        /*    if (GetComponent<XRGrabInteractable>().isSelected)
            {

            }*/
        /*  if (poseAction.GetState()){
              return GrabTypes.Grip;
      }
          if (m_ActionReference.action.enabled == true)
          {
              Debug.Log("true");
          }
          Debug.Log("false");
      }*/
        // Start is called before the first frame update
    }
}
