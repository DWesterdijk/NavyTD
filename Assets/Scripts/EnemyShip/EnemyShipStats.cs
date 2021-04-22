using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipStats : MonoBehaviour
{
    public float Health;

    private void Update()
    {
        if (this.GetComponent<GuiHealthBar>().currentHealth <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
