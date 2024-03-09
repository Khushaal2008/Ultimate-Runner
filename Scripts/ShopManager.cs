using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characterModels;

    public Blueprint[] characters;

    public Button buyButton;
    public Text characterName;

    void Start()
    {
        foreach(Blueprint character in characters)
        {
            if(character.price == 0)
            character.isUnlocked = true;
            else
                character.isUnlocked = PlayerPrefs.GetInt(character.name,0) == 0 ? false:true;
        }

        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter",0);
        foreach (GameObject character in characterModels)
            character.SetActive(false);

            characterModels[currentCharacterIndex].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();

    }

    public void ChangeNext()
    {
        characterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex++;
        if(currentCharacterIndex == characterModels.Length)
        currentCharacterIndex = 0;
        

        characterModels[currentCharacterIndex].SetActive(true);
        Blueprint c = characters[currentCharacterIndex];
        if(!c.isUnlocked)
        return;
        PlayerPrefs.SetInt("SelectedCharacter",currentCharacterIndex);
    }

    public void ChangePrevious()
    {
        characterModels[currentCharacterIndex].SetActive(false);
        currentCharacterIndex--;
        if(currentCharacterIndex == -1)
        currentCharacterIndex = characterModels.Length - 1;

        

        characterModels[currentCharacterIndex].SetActive(true);

        Blueprint c = characters[currentCharacterIndex];
        if(!c.isUnlocked)
        return;
        PlayerPrefs.SetInt("SelectedCharacter",currentCharacterIndex);
    }

    public void UnlockCharacter()
    {
        Blueprint c = characters[currentCharacterIndex];
        PlayerPrefs.SetInt(c.name,1);
        PlayerPrefs.SetInt("SelectedCharacter",currentCharacterIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoins",PlayerPrefs.GetInt("NumberOfCoins",0) - characters[currentCharacterIndex].price);
    }

    private void UpdateUI()
    {
        Blueprint c = characters[currentCharacterIndex];
        if(c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
        characterName.GetComponent<Text>().text = c.name;
        }
        else
        {
            buyButton.gameObject.SetActive(true);
        characterName.GetComponent<Text>().text = c.name;
            buyButton.GetComponentInChildren<Text>().text = "Buy - " + c.price;
            if(c.price < PlayerPrefs.GetInt("NumberOfCoins",0))
            {
                buyButton.interactable = true;
            }
            else
            {
                 buyButton.interactable = false;

            }
        }
    }
}
