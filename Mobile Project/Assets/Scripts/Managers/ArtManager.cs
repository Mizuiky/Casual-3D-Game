using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ArtManager : MonoBehaviour
{
    [SerializeField]
    private List<ArtSetup> _artSetup;

    [SerializeField]
    private ColorManager _colorManager;

    public GameObject GetArtByType(ArtType type)
    {
        var art = _artSetup.Where(x => x.type == type).Select(x => x.art).FirstOrDefault();

        if(art != null)
            return art;

        return null;
    }

    public void SetArtColor(ArtType type)
    {
        _colorManager.SetColorByArtType(type);
    }
}

public enum ArtType
{
    Default,
    Forest1,
    Forest2
}

[System.Serializable]
public class ArtSetup
{
    public ArtType type;
    public GameObject art;
}
