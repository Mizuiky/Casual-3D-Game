using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArtManager : MonoBehaviour
{
    [SerializeField]
    private List<ArtSetup> _artSetup;

    //public ArtSetup GetArtByType(ArtType type)
    //{
    //    //var artes = _artSetup.ForEach(x => x.type == type);

    //    //return artes;
    //}
}

public enum ArtType
{
    Planet1,
    Planet2
}

[System.Serializable]
public class ArtSetup
{
    public ArtType type;
    public GameObject art;
}
