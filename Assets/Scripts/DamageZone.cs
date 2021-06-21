using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageZone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        RubyController rbController = collision.GetComponent<RubyController>();

        if(rbController != null)
        {
            rbController.ChangeHealth(-1);
        }
    }
}
