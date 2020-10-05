//Author: Sophie Hester

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    private int selectedCharacterIndex;
    private Color desiredColour;

    [Header("list of characters")]
    [SerializeField] private List<CharacterSelectObject> characterList = new List<CharacterSelectObject>();

    [Header("UI References")]
    [SerializeField] private Text characterName;
    [SerializeField] private Image characterSplash;
    [SerializeField] private Image backgroundColour;
    [SerializeField] private GameObject Instructions;
    [SerializeField] private GameObject SelectionScreen;

    [Header("Sounds")]
    [SerializeField] private AudioClip arrowCLickSFX;
    [SerializeField] private AudioClip characterSelectMusic;

    private void Start()
    {
        UpdateCharacterSelectionUI();
       // AudioManager.instance.PlayMusic(characterSelectMusic);
    }

    public void LeftArrow()
    {
        selectedCharacterIndex--;
        if (selectedCharacterIndex < 0) 
            selectedCharacterIndex = characterList.Count - 1;

        UpdateCharacterSelectionUI();
        //AudioManager.instance.PlayMusic(arrowCLickSFX);
    }

    public void RightArrow()
    {
        selectedCharacterIndex++;
        if (selectedCharacterIndex == characterList.Count) selectedCharacterIndex = 0;

        UpdateCharacterSelectionUI();
    }

    public void Confirm()
    {
        Instructions.gameObject.SetActive(true);
        SelectionScreen.gameObject.SetActive(false);
        //Debug.Log(string.Format("Character {0}:{1} has been chosen!", selectedCharacterIndex, characterList[selectedCharacterIndex].characterName));
    }
    private void UpdateCharacterSelectionUI()
    {
        // Splash, Name, Desired Colour
       characterSplash.sprite = characterList[selectedCharacterIndex].splash;
       characterName.text = characterList[selectedCharacterIndex].characterName;
       backgroundColour.color = characterList[selectedCharacterIndex].characterColour;
    }

    [System.Serializable]
    public class CharacterSelectObject
    {
        public Sprite splash;
        public string characterName;
        public Color characterColour;
    }
}
