using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 5.0f;
    public bool vertical;
    public float changeTime = 3.0f;

    Rigidbody2D rigidbody2D_Enemy;
    float timer;
    int direction = 1;
    Animator enemyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D_Enemy = GetComponent<Rigidbody2D>();
        timer = changeTime;

        enemyAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D_Enemy.position;

        if (vertical)
        {
            position.y = position.y + Time.deltaTime * speed * direction; ;

            enemyAnimator.SetFloat("MoveX", 0);
            enemyAnimator.SetFloat("MoveY", direction);
        }
        else
        {
            position.x = position.x + Time.deltaTime * speed * direction;

            enemyAnimator.SetFloat("MoveX", direction);
            enemyAnimator.SetFloat("MoveY", 0);
        }

        rigidbody2D_Enemy.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        RubyController player = other.gameObject.GetComponent<RubyController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
