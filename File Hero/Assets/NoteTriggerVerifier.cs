using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteTriggerVerifier : MonoBehaviour
{
    public bool hasTriggered = false;
    public string noteValue = "";
    public int notePoints = 0;
    public NoteTypeSpecifier noteTypeSpecifier;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == noteTypeSpecifier.noteType)
        {
            hasTriggered = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == noteTypeSpecifier.noteType)
        {
            hasTriggered = false;
        }
    }


}