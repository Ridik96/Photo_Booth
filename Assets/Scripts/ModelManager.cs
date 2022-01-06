using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelManager : Singleton<ModelManager>
{
    public Transform tSpawnPoint;
    public UIManager m_UIButtons;
    public Object[] model;
   [HideInInspector] public GameObject target;
   [HideInInspector] public int currentIndex;

    void Start()
    {
        string path = "Input/Prefabs";
        model = Resources.LoadAll(path, typeof(GameObject));
        SpawnModel(0);
        m_UIButtons.OnChangeModel();
    }
    
    private void SpawnModel(int number)
    { 
        target = (GameObject)model[number];
        Instantiate(target, tSpawnPoint);
        currentIndex = number;
    }

    public void ModelChange(int index)
    {
        Destroy(tSpawnPoint.GetChild(0).gameObject);
        SpawnModel(index);
    }

}
