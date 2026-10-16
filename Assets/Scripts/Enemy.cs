using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class Enemy : MonoBehaviour
{
#if UNITY_EDITOR
    public float speed = 2f;
    public Transform[]  points;
    private int i;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
         spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.25f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
        spriteRenderer.flipX =( transform.position.x - points[i].position.x)<0f;
    }
#endif
}
