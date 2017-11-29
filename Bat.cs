using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bat : IComparable<Bat>
{
    //inizialising values for bat
    public string name;
    public string state;
    public int damage;
    public int value;

    //creating new bat 
    public Bat(String newName, String newState, int newDamage, int newValue) {

        name = newName;
        state = newState;
        damage = newDamage;
        value = newValue;
    }
    public int CompareTo(Bat other)
    {
        if (other == null) {
            return 1;
        }

        return damage - other.damage;
    }
}
