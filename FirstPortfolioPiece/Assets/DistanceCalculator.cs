using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DistanceCalculator : MonoBehaviour
{
    public float distance;
    public TextMeshProUGUI distanceText;
    public ScrollSpeed gameManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distanceText.text = Mathf.RoundToInt(distance).ToString() + "M";   
    }

    private void FixedUpdate()
    {
        distance += Time.fixedDeltaTime *gameManager.speed/3.28f; // ft is pretty well accurate for dist, but the number is large. so lets convert to meters
    }
}
