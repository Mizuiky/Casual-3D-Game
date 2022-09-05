using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Props : MonoBehaviour
{
    public GameObject[] props;

    public Transform[] positions;

    public Transform propContainer;

    public bool ChildPrefabs
    {
        get => childList.Count > 0;
    }

    private List<GameObject> childList = new List<GameObject>();
    private int propIndex;

    public void InstantiateProps()
    {
        for(int i = 0; i < positions.Length; i++)
        {
            propIndex = i;

            if (propIndex >= props.Length)
                propIndex = 0;

            var obj = Instantiate(props[propIndex], positions[i].transform);

            if(obj != null)
            {
                obj.transform.position = positions[i].position;
                childList.Add(obj);
            }         
        }
    }

    public bool CheckIfCanInstantiate()
    {
        return propContainer != null && props.Length > 0 && !DetectNullFields(props) && positions.Length > 0 && !DetectNullFields(positions);
    }

    public void DeleteElements()
    {
        childList.ForEach(x => DestroyImmediate(x));
        childList.Clear();
    }

    private bool DetectNullFields<T>(T[] array)
    {
        foreach (T obj in array)
        {
            if (obj == null || obj.ToString().Contains("null"))
                return true;            
        }
             
        return false;
    }
}
