using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Danger : MonoBehaviour
{
    Rigidbody2D rb;
    float t;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t += Time.fixedDeltaTime;
        float magnitude = 0.01f * Mathf.Sin((t / 3) * 2 * Mathf.PI);
        float magnitudey = 0.009f * Mathf.Cos((t / 3) * 2 * Mathf.PI);
        float mags = 0.006f * Mathf.Sin((t / 6) * 2 * Mathf.PI);
        Vector3 newPos = transform.position;
        Vector3 newSize = transform.localScale;
        newPos.x += magnitude;
        newPos.y += magnitudey;
        newSize.x += mags;
        newSize.y += mags;
        transform.position = newPos;
        transform.localScale = newSize;
    }
}
