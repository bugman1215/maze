using UnityEngine;

public class VanishingBox : MonoBehaviour
{

    private void Update()
    {
        bool hasMonster = FindObjectOfType<Monster>();
        if (!hasMonster) {
            Destroy(gameObject);
        }
    }
}
