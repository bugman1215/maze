using UnityEngine;

public class Follow_player : MonoBehaviour
{

    public Player player;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 0.5f, -2);
        transform.rotation = player.transform.rotation;
    }
}