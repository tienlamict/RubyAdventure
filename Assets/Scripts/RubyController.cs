using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector2 pos = transform.position;
        pos.x = pos.x + 3f * horizontal * Time.deltaTime;
        pos.y = pos.y + 3f * vertical * Time.deltaTime;
        transform.position = pos;
    }
}
