using UnityEngine;

public class Follow_player : MonoBehaviour
{

    public Player player;

    // Update is called once per frame
    private void Start()
    {
        transform.Rotate(Vector3.right * 30);
    }
    void Update()
    {
        transform.position = player.transform.position + new Vector3(0, 2f,-2f);
        //transform.rotation = player.transform.rotation;

    }
}