using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    private int modelIndex;
    private int lastIndex;
   
    public void OnChangeModel()
    {
        modelIndex = ModelManager.Instance.currentIndex;
        lastIndex = ModelManager.Instance.model.Length - 1;
    }

    public void OnNextModel()
    {
        if (modelIndex < lastIndex)
        {
            modelIndex++;
        }
        else
        {
            modelIndex = 0;
        }
        ModelManager.Instance.ModelChange(modelIndex);
    }
    public void OnPreviousModel()
    {
        if (modelIndex <= 0)
        {
            modelIndex = lastIndex;
        }
        else
        {
            modelIndex--;
        }
        ModelManager.Instance.ModelChange(modelIndex);
    }

}
