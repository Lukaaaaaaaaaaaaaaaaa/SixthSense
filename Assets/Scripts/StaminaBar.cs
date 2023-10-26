using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StaminaBar : MonoBehaviour
{
    public float stamina = 100;
    float maxstamina;


    public Slider staminaBar;
    public float dValue;

    public bool decreaseStamina = false;

    public Moinster monster;

    // Start is called before the first frame update
    void OnEnable()
    {
        maxstamina = 100;
        staminaBar.maxValue = maxstamina;
        stamina = staminaBar.value;

        stamina = maxstamina;
    }

    // Update is called once per frame
    void Update()
    {
        if (monster.loseStamina)
        {
            DecreaseEnergy();
        }

       //if (Input.GetButton("Fire3") && )
       //     DecreaseEnergy();
        if (stamina != maxstamina)
            IncreaseEnergy();

        staminaBar.value = stamina;

        if(stamina >= maxstamina)
        {
            stamina = maxstamina;
        }

        if(stamina <= 0)
        {
            stamina = 0;
        }

    }
    public void DecreaseEnergy()
    {
        Debug.Log("poopoo");

        if (stamina != 0)
            stamina -= dValue * Time.fixedDeltaTime;
        decreaseStamina = false;
    }

    private void IncreaseEnergy()
    {  
        if(stamina < maxstamina)
        {
            stamina += dValue * Time.deltaTime;
        }
           
    }
}
