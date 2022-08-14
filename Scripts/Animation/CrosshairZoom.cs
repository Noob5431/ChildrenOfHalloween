using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairZoom : MonoBehaviour
{
    public GameObject gun, dot;
    public float speed, maxScale, minScale;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();
    }
    void Update()
    {
        bool isRanged = gun.GetComponent<Attack>().isRanged;

        if (isRanged && rectTransform.localScale.x < maxScale)
        {
            rectTransform.localScale = new Vector3(rectTransform.localScale.x + speed*Time.deltaTime,
                                                   rectTransform.localScale.y + speed*Time.deltaTime,
                                                   rectTransform.localScale.z);
            if (rectTransform.localScale.x > maxScale)
                rectTransform.localScale = new Vector3(maxScale,
                                                   maxScale,
                                                   rectTransform.localScale.z);
            dot.SetActive(false);
        }

        else if (!isRanged && rectTransform.localScale.x > minScale)
        {
            rectTransform.localScale = new Vector3(rectTransform.localScale.x - speed * Time.deltaTime,
                                                   rectTransform.localScale.y - speed * Time.deltaTime,
                                                   rectTransform.localScale.z);
            if (rectTransform.localScale.x < minScale)
                rectTransform.localScale = new Vector3(minScale,
                                                   minScale,
                                                   rectTransform.localScale.z);
            if (rectTransform.localScale.x == minScale)
                dot.SetActive(true);
        }
    }
}
