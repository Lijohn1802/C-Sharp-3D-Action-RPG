﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if(newItem != null)
        {
            Armor.AddModifier(newItem.armorModifier);
            Damage.AddModifier(newItem.damageModifier);
        }
        if (oldItem != null)
        {
            Armor.AddModifier(oldItem.armorModifier);
            Damage.AddModifier(oldItem.damageModifier);
        }
    }
    

}
