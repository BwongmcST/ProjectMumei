using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerManagement
{
    public class StateBar : MonoBehaviour
    {
        [SerializeField] private Slider _Hpslider;
        [SerializeField] private Slider _staminaslider;

        public void SetMaxHealth(int health)
        {
            _Hpslider.maxValue = health;
            _Hpslider.value = health;
        }
        public void SetHealth(int health)
        {
            _Hpslider.value = health;
        }

        public void SetMaxStamina(float stamina)
        {
            _staminaslider.maxValue = stamina;
            _staminaslider.value = stamina;
        }

        public void SetStamina(float stamina)
        {
            _staminaslider.value = stamina;
        }
    }
}
