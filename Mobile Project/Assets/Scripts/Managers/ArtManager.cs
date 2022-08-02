using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArtManager : MonoBehaviour
{
    [SerializeField]
    private List<ArtSetup> _artSetup;

    public GameObject GetArtByType(ArtType type)
    {
        var art = _artSetup.Where(x => x.type == type).Select(x => x.art).FirstOrDefault();

        return art;
    }
}

public enum ArtType
{
    Forest1,
    Forest2
}

[System.Serializable]
public class ArtSetup
{
    public ArtType type;
    public GameObject art;
}
