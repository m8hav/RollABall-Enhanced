using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }


    // The simple Update doesn't have a guaranteed order of execution and so Update in all scripts run in parallel in random order, resulting in one Update from one script running before another Update in another script in one execution and in a different order in the next execution.
    // So using the simple Update would have resulted in unexpected output because the camera position could get updated before the player position was updated.
    // LateUpdate, however, is called once per frame after Updates from all other scripts or unity systems have run
    // So the camera will always be updated only after the player has moved
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
