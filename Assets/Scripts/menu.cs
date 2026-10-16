using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class menu : MonoBehaviour
{
#if UNITY_EDITOR
    public void startGame()

    {
#if UNITY_ANDROID || UNITY_IOS
        Debug.Log("This code only exists on Mobile builds!");
        SetupMobileTouchControls();
#elif UNITY_WEBGL
        Debug.Log("This code only exists on Web browser builds!");
        DisableHeavyGraphics();
 
#endif


        SceneManager.LoadScene("Gamescene");
        
    }
    public void quitGame()
    {         Application.Quit();
    }
#endif
}
