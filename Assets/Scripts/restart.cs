using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class NewBehaviourScript : MonoBehaviour
{
#if UNITY_EDITOR
    public void LoadCurrentScene()
    {

#if UNITY_ANDROID || UNITY_IOS
        Debug.Log("This code only exists on Mobile builds!");
        SetupMobileTouchControls();
#elif UNITY_WEBGL
        Debug.Log("This code only exists on Web browser builds!");
        DisableHeavyGraphics();
 
#endif

        UnityEngine.SceneManagement.SceneManager.LoadScene("Gamescene");
        Time.timeScale = 1;
    }
#endif
}
