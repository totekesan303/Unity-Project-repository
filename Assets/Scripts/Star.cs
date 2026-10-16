using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class Star : MonoBehaviour
{
#if UNITY_EDITOR
    public GameObject winUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            winUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
#endif
}
