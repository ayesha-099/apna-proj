using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    [SerializeField] private Image _healthbarSprie;
    // Start is called before the first frame update
   public void Updatehealthbar(float maxHealth , float CurrentHealth)
    {
        _healthbarSprie.fillAmount = CurrentHealth / maxHealth;
    }    
}
