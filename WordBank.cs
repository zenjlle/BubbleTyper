using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject typerDisplay;

    private List<string> originalWords = new List<string>()
    {
        "Parship",
        "Green Bean",
        "Cauliflower",
        "Potato",
        "Tulip",
        "Kale",
        "Jazz",
        "Garlic",
        "Rhubarb",
        "Strawberry",
        "Hops",
        "Tomato",
        "Hot Pepper",
        "Blueberry",
        "Melon",
        "Poppy",
        "Radish",
        "Red Cabbage",
        "Starfruit",
        "Corn",
        "Eggplant",
        "Pumpkin",
        "Yam",
        "Cranberries",
        "Sunflower",
        "Beet",
        "Amaranth",
        "Artichoke",
        "Coffee Bean",
        "Ancient Fruit",
        "Wheat",
        "Rice",
        "Fairy Rose",
        "Giant Cauliflower",
        "Giant Pumpkin",
        "Giant Melon"
    };

    private List<string> workingWords = new List<string>();

    private void Awake()
    {
        typerDisplay.SetActive(true);
        endScreen.SetActive(false);

        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
        ConvertToLower(workingWords);
    }

    private void Shuffle(List<string> list)
    {
    for (int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temporary = list[i];

            list[i] = list[random];
            list[random] = temporary;
        }
    }

    private void ConvertToLower(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if(workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        } else
        {
            typerDisplay.SetActive(false);
            endScreen.SetActive(true);
        }
        return newWord;
    }
}
