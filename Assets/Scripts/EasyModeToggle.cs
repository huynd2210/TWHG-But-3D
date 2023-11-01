using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EasyModeToggle : MonoBehaviour
{
    public Toggle easyModeToggle;
    public static bool isEasyMode = false;
    
    public void ToggleEasyMode()
    {
        int toggleState = easyModeToggle.isOn ? 1 : 0;
        isEasyMode = toggleState == 1;
        Debug.Log("EasyModeToggle: " + isEasyMode);
    }    

}
