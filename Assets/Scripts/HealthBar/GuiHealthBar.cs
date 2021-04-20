using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuiHealthBar : MonoBehaviour
{
    public Texture healthBar;
    public Color color1;

    //Debug values
    //TODO: replace debug value's with health of the ship.
    public float currentHealth;
    public float maxHealth;
    //------------

    public int healthBarLength;
    public int healthBarHeight;

    private float _sliderValue;

    private void Start()
    {
        maxHealth = this.GetComponent<EnemyShipStats>().Health;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        HealthBarSlider(currentHealth, maxHealth);
    }

    private void OnGUI()
    {
        var position = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        position.y = Screen.height - position.y;

        GUI.color = color1;
        GUI.DrawTexture(new Rect(position.x - (healthBarLength / 2), position.y - (healthBarHeight + 10), healthBarLength / _sliderValue, healthBarHeight), healthBar);
    }

    public void HealthBarSlider(float currentHealth, float maxHealth)
    {
        _sliderValue = maxHealth / currentHealth;
    }
}
