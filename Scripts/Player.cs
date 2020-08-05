using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    public float movespeed;
    public float rotateamount;
    public float rot;
    int score;
    public GameObject WinT;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousepos.x < 0)
            {
                rot = rotateamount;
            }
            else
            {
                rot = -rotateamount;
            }
            transform.Rotate(0, 0, rot);
        }
        

    }
    private void FixedUpdate()
    {
        rb.velocity = transform.up * movespeed;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            score++;
            if(!(score%2 == 0))
            {
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.color = new Color(0.5215687f, 0.8980392f, 0.7451147f, 1f); // Lime green
            }
            else
            {
                SpriteRenderer renderer = GetComponent<SpriteRenderer>();
                renderer.color = new Color(0.89f, 0.5199804f, 0.5199804f);
            }
            if (score == 9)
            {
                
                WinT.SetActive(true);
            }

        }
        else if(collision.gameObject.tag == "Danger")
        {
            SceneManager.LoadScene("Start");
        }
    }

}

