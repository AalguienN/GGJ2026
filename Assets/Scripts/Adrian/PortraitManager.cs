using UnityEngine;

public class PortraitManager : MonoBehaviour
{
    public static PortraitManager Instance;
    public SpriteRenderer Portrait;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        Portrait = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePortrait(Sprite spr) {
        Portrait.sprite = spr; 
    }
}
