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

    public void SetColorsByArtType(ArtType type)
    {

    }
}

[System.Serializable]
public class ColorSetup
{
    public ArtType type;
    public List<Color> colors;
}
