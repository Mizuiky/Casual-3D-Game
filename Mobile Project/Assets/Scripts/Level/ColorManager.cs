using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    private void Start()
    {
        //SetDefaultColors();
    }

    public void SetColorByArtType(ArtType type)
    {
        if (type != ArtType.Default)
        {
            var colorSetup = _colorSetup.Find(x => x.type == type);

            for (int i = 0; i < _materials.Count; i++)
            {
                _materials[i].SetColor("_Color", colorSetup.colors[i]);
            }
        }
        else
            SetDefaultColors();
    }

    public void SetDefaultColors()
    {
        for (int i = 0; i < _materials.Count; i++)
        {
            _materials[i].SetColor("_Color", _defaultColors[i]);
        }
    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtType type;
    public List<Color> colors;
}
