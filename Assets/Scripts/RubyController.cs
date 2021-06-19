using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    //This creates a new variable called rigidbody2d to store the Rigidbody and access it from anywhere inside your script
    Rigidbody2D rigibody;

    float horizontal;
    float vertical;

    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        rigibody = GetComponent<Rigidbody2D>(); // Gan Rigibody cua obj dc gan script nay vao bien rigibody
    }

    void Update()
    {
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    {
        Vector2 pos = rigibody.position;
        pos.x = pos.x + 5f * horizontal * Time.deltaTime;
        pos.y = pos.y + 5f * vertical * Time.deltaTime;

        /* In the same way, instead of setting the new position with transform.position = position; 
         you are now doing it with the Rigidbody position. This line of code will move the Rigidbody 
         to where you want, but will stop it mid-way instead if it collides with another Collider in that movement */
        rigibody.MovePosition(pos);
    }
}
