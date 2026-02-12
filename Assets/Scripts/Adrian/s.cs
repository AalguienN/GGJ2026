using UnityEngine;

public class s : MonoBehaviour
{
    [SerializeField] private PiumPium shootAnim;  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShootAnim()
    {
        shootAnim.ShootAnim(); 
    }
}
