using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class jem : MonoBehaviour
{
#if UNITY_EDITOR
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag  == "Player")
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.jem  += 1;
            Destroy(gameObject);
        }
    }
#endif
}
