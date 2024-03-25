using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParagraphWordBank : MonoBehaviour
{
    public GameObject endScreen;
    public GameObject typerDisplay;

    private List<string> originalWords = new List<string>()
    {
        "The FitnessGram Pacer Test is a multistage aerobic capacity test that progressively gets more difficult as it continues. Students begin at the starting line. Once the test begins, the running speed starts slowly, but gets faster each minute after you hear the signal.",
        "People never change. Science tells us that our genetic imprint predetermined your faith, your character, your choices. Pinanganak kang bobo, lalaki kang bobo, mamamatay kang bobo.",
        "Dahil dyan meron ka ng hanabishi appliances at meron ka pang libreng semento mula sa Republic cement (tibay mula sa loob) pwede ka pang mag karoon ng bahay mula sa lumina homes at meron ka pang bagong suzuki raider galing sa motor trade",
        "Pwede pakopya? Ayaw mo? Sige okay lang hindi na lang kita kukulitin sanay naman akong walang tumutulong sakin eh tsaka baka busy ka. Pasensya ka na ha eto lang kasi ako eh, bobo. Sana hindi mo na lang ako naging kaklase no?",

    };

    private List<string> workingWords = new List<string>();

    private void Awake()
    {
        typerDisplay.SetActive(true);
        endScreen.SetActive(false);

        workingWords.AddRange(originalWords);
        Shuffle(workingWords);
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
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    public string GetWord()
    {
        string newWord = string.Empty;

        if (workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        else
        {
            typerDisplay.SetActive(false);
            endScreen.SetActive(true);
        }
        return newWord;
    }
}
