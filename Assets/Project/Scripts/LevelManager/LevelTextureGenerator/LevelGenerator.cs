using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    public int textureWidth = 8;
    public Texture2D[] levels;
    
    private Texture2D currentTexture;
    private int currentTextureIndex = 0;
    private int currentAxis = 0;

    public void StartGame()
    {
        currentAxis = 0;
        currentTextureIndex = 0;
        currentTexture = levels[currentTextureIndex];
    }

    public List<int> GetPositions(int level)
    {
        if(currentTexture == null)
        {
            currentTexture = levels[currentTextureIndex];
        }
        List<int> positions = new List<int>();
        int pos = level - currentAxis;
        Debug.Log(pos);
        int texSizeY = (int)currentTexture.height;
        Debug.Log(texSizeY);

        if (pos >= texSizeY)
        {
            currentAxis = texSizeY;
            GetNextTexture();
        }

        for (int i = 0; i < textureWidth; i++)
        {
            if (currentTexture.GetPixel(i, pos).a != 0)
            {
                positions.Add(i - (texSizeY / 2) );
            } 
        }

        return positions;
    }

    void GetNextTexture()
    {
        currentTextureIndex++;
        if (levels.Length <= currentTextureIndex)
        {
            currentTextureIndex = 0;
        }
        currentTexture = levels[currentTextureIndex];
    }
}
