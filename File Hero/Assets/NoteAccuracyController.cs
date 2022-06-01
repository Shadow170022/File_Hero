using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAccuracyController : MonoBehaviour
{
    public NoteTypeSpecifier noteTypeSpecifier;
    public NoteKeyController noteKeyController;
    public GameObject[] childVerifiers;
    private string noteType;
    // Start is called before the first frame update
    void Start()
    {
        noteType = noteTypeSpecifier.noteType;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        if(noteKeyController.noteVerifierPressed){
            if (other.gameObject.tag == noteType)
            {
                //Check for every childVerifiers if it has a trigger
                foreach (GameObject childVerifier in childVerifiers)
                {
                    NoteTriggerVerifier childTriggerVerifier = childVerifier.GetComponent<NoteTriggerVerifier>();
                    if (childTriggerVerifier.hasTriggered)
                    {
                        //Change tag of other to "Untagged"
                        other.gameObject.tag = "Untagged";
                        Debug.Log("NoteValue: " + childTriggerVerifier.noteValue);
                        Debug.Log("NotePoints: " + childTriggerVerifier.notePoints);
                        childTriggerVerifier.hasTriggered = false;
                        break;
                    }
                }
            }
        }
    }

}
