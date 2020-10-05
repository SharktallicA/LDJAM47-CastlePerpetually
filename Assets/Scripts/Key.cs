using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Sophie Hester
public class Key : MonoBehaviour
{
    [SerializeField] private KeyType keyType;
    public enum KeyType
    {
        Yellow,
        Blue,
        Red
    }

    public KeyType GetKeyType()
    {
        return keyType;
    }
}
