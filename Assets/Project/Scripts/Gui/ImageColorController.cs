using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ImageColorController : MonoBehaviour
{
    public ColorManager colors;
    public Image img;
    public SpriteRenderer spriteRender;
    public bool randomColor;

    private void OnEnable()
    {
        if (randomColor && colors)
        {
            if (img)
            {
                img.color = colors.RandomColor;
            }
            if (spriteRender)
            {
                spriteRender.color = colors.RandomColor;
            }
        }
    }
}
