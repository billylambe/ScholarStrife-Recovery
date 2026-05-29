using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ArtworkEntry
{
    [Header("Artwork")]
    public string artworkID;
    public Sprite artworkSprite;
}

public class ArtworkManager : MonoBehaviour
{
    public static ArtworkManager Instance;
    [Header("Artwork Database")]
    public List<ArtworkEntry> artworkLibrary = new List<ArtworkEntry>();

    private void Awake()
    {
        Instance = this;
    }

    public Sprite GetArtwork(string id)
    {
        foreach(ArtworkEntry entry in artworkLibrary)
        {
            if (entry.artworkID == id)
            {
                return entry.artworkSprite;
            }
        }
        return null;
    }

}
