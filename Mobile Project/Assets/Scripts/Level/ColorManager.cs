using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [Header("Colors and Materials")]

    [SerializeField]
    private List<Material> _materials;

    [SerializeField]
    private List<ColorSetup> _colorSetup;

    [SerializeField]
    private List<Color> _defaultColors;

    public void SetColorByArtType(ArtType type)
    {
        var colorSetup = _colorSetup.Find(x => x.type == type).colors;

        for(int i = 0; i < _materials.Count; i++)
        {
            _materials[i].SetColor("_Color", colorSetup[i]);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtType type;
    public List<Color> colors;
}
