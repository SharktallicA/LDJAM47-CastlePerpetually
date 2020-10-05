using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIKeyHolder : MonoBehaviour
{
    [SerializeField] private KeyHolder keyHolder;
    private Transform container;
    private Transform keyTemplate;

    private void Awake()
    {
        container = transform.Find("Container");
        keyTemplate = container.Find("KeyTemplate");
        keyTemplate.gameObject.SetActive(false);
    }

    private void Start()
    {
        keyHolder.onKeysChanged += KeyHolder_onKeysChanged;
    }

    private void KeyHolder_onKeysChanged(object sender, EventArgs e)
    {
        UpdateVisual();
    }

    private void UpdateVisual()
    {
        foreach(Transform child in container)
        {
            if (child == keyTemplate) continue;
            Destroy(child.gameObject);
        }
        List<Key.KeyType> keyList = keyHolder.GetKeyList();
        for (int i = 0; i < keyList.Count; i++)
        {
            Transform keyTransform = Instantiate(keyTemplate, container);
            keyTemplate.gameObject.SetActive(true);
            Key.KeyType keyType = keyList[i];
            keyTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(100 * i, 0);
            Image keyImage = keyTransform.Find("image").GetComponent<Image>();
            switch (keyType)
            {
                default:
                case Key.KeyType.Yellow:keyImage.color = Color.yellow; break;
                case Key.KeyType.Red: keyImage.color = Color.red; break;
                case Key.KeyType.Blue: keyImage.color = Color.blue; break;
            }

        }
    }
}
