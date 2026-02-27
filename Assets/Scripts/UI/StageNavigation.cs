using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class StageNavigation : MonoBehaviour
{
    [SerializeField] private LevelSelectSO levelSelected;
    [SerializeField] private List<GameObject> stages;
    private int currentIndex = 0;
    public void NextStage()
    {
        if(currentIndex < stages.Count - 1)
        {
            stages[currentIndex].SetActive(false);
            currentIndex++;
            stages[currentIndex].SetActive(true);
            levelSelected.levelSelected = currentIndex;
        } else
        {
            stages[currentIndex].SetActive(false);
            currentIndex = 0;
            stages[currentIndex].SetActive(true);
            levelSelected.levelSelected = currentIndex;
        }
    }

    public void PreviousStage()
    {
        if (currentIndex != 0)
        {
            stages[currentIndex].SetActive(false);
            currentIndex--;
            stages[currentIndex].SetActive(true);
            levelSelected.levelSelected = currentIndex;
        } else
        {
            stages[currentIndex].SetActive(false);
            currentIndex = stages.Count - 1;
            stages[currentIndex].SetActive(true);
            levelSelected.levelSelected = currentIndex;
        }
    }
}
