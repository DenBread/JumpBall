using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPoint : MonoBehaviour
{
    public List<SpriteRenderer> spriteRenderers;
    private int maxIndex;
    private int saveIndex;
    public Color yellow;
    public Color yellowGray;

    private void Start()
    {
        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            maxIndex++;
        }

        saveIndex = 1;
        SwitchingColors(Color.yellow, true);
    }

    public void SwitchingColors(Color color, bool newColor)
    {
        if (newColor)
        {
            int index = Random.Range(0, maxIndex);
            while (saveIndex == index)
            {
                index = Random.Range(0, maxIndex);
            }
            Debug.Log($"Новые число: {index}, сох число: {saveIndex}");
            saveIndex = index;
        }


        for (int i = 0; i < spriteRenderers.Count; i++)
        {
            if (i == saveIndex)
            {
                spriteRenderers[i].color = yellow;
            }
            else
            {
                spriteRenderers[i].color = yellowGray;
            }
        }
    }

}
