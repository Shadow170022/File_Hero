using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteKeyController : MonoBehaviour
{
    public bool noteVerifierPressed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //change noteVerifierPressed to true if space is pressed, false if space is not pressed
        noteVerifierPressed = Input.GetKey(KeyCode.Space);
    }
}
