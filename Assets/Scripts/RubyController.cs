using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyController : MonoBehaviour
{
    private float speed = 5.0f;
    public int maxHealth = 5;

    // Để tối ưu hóa hệ thống thì hệ thống vật lý sẽ ngừng tính toán khi obj ngừng chuyển động
    // khi đó Rigibody rơi vào trạng thái ngủ, trong trường hợp này ta không muốn Rigibody ngủ
    // => active chế độ Sleeping Mode to Never Sleep
    public float timeInvincible = 2.0f;
    bool isInvincible = false;
    float invincibleTimer;

    public int health { get { return currentHealth; } }
    private int currentHealth;

    Rigidbody2D rigibody;

    float horizontal;
    float vertical;


    void Start()
    {
        //QualitySettings.vSyncCount = 0;
        //Application.targetFrameRate = 10;
        rigibody = GetComponent<Rigidbody2D>(); // Gan Rigibody cua obj dc gan script nay vao bien rigibody
        currentHealth = maxHealth;
    }

    void Update()
    {
         horizontal = Input.GetAxis("Horizontal");
         vertical = Input.GetAxis("Vertical");


        if (isInvincible)   
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector2 pos = rigibody.position;
        pos.x = pos.x + speed * horizontal * Time.deltaTime;
        pos.y = pos.y + speed * vertical * Time.deltaTime;

        /* In the same way, instead of setting the new position with transform.position = position; 
         you are now doing it with the Rigidbody position. This line of code will move the Rigidbody 
         to where you want, but will stop it mid-way instead if it collides with another Collider in that movement */
        rigibody.MovePosition(pos);
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible)
            {
                return;
            }

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }

        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);
    }
}
