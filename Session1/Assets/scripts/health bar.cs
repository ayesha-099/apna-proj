using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
   
    [SerializeField] private Slider slider;
    // Start is called before the first frame update
    public void UpdatehealthbarEnemy(float maxHealth , float CurrentHealth)
    {
        slider.value = CurrentHealth / maxHealth; 
    }    
}
