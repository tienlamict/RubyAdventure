using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        RubyController rbController = other.GetComponent<RubyController>();

        if(rbController != null)
        {
            if(rbController.health < rbController.maxHealth)
            {
                rbController.ChangeHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
