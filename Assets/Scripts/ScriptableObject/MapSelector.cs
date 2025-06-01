using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class MapSelector : MonoBehaviour
{
    [SerializeField] private LevelSelectSO levelSelected;
    [SerializeField] private GameObject defaultLevel;
    [SerializeField] private List<GameObject> levels;
    private void Start()
    {
        if(levelSelected != null)
        {
            switch (levelSelected.levelSelected)
            {
                case 0:
                    defaultLevel.SetActive(true);
                    break;
                default:
                    Instantiate(levels[levelSelected.levelSelected]);
                    break;
            }
        }
    }
}
