using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LevelsStateManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttonObjects;
    void Start()
    {
        int unlockedNums = DataManager.Instance.GetNumberOfLevelsUnlocked();
        for (int index = unlockedNums; index < buttonObjects.Count; index++)
        {
            Button button = buttonObjects[index].GetComponent<Button>();
            button.interactable = false;
        }
    }
    void Update()
    {
        
    }
}
