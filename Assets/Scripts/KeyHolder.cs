using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Sophie Hester
public class KeyHolder : MonoBehaviour
{
    public event EventHandler onKeysChanged;
    private List<Key.KeyType> keyList;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
        onKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
        onKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        Key key = collider.GetComponent<Key>();
        if (key != null )
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        KeyDoor keyDoor = collider.GetComponent<KeyDoor>();
        if (keyDoor != null)
        {
           if (ContainsKey (keyDoor.GetKeyType()))
            {
                //Currently holding key to open this door
                RemoveKey(keyDoor.GetKeyType());
                keyDoor.OpenDoor();
            }
        }

    }
}
