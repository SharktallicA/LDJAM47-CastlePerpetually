using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Sophie Hester
public class KeyDoor : MonoBehaviour
{
    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}
