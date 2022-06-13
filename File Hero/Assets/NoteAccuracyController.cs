using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteAccuracyController : MonoBehaviour
{
    public NoteKeyController noteKeyController;
    public GameObject[] childVerifiers;
    public string noteType;
    public PointsController pointsController;
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
        if(noteKeyController.noteVerifierPressed && noteKeyController.isEnabled){
            if (other.gameObject.tag == noteType)
            {
                noteKeyController.isEnabled = false;
                noteKeyController.badNoteParticleSystem.Clear();
                noteKeyController.goodNoteParticleSystem.Clear();
                noteKeyController.perfectNoteParticleSystem.Clear();
                //Check for every childVerifiers if it has a trigger
                foreach (GameObject childVerifier in childVerifiers)
                {
                    NoteTriggerVerifier childTriggerVerifier = childVerifier.GetComponent<NoteTriggerVerifier>();
                    if (childTriggerVerifier.hasTriggered)
                    {
                        //Change tag of other to "Untagged"
                        other.gameObject.tag = "Untagged";
                        //Debug.Log("NoteValue: " + childTriggerVerifier.noteValue);
                        //Debug.Log("NotePoints: " + childTriggerVerifier.notePoints);
                        pointsController.AddPoints(childTriggerVerifier.notePoints);
                        //play NoteParticleSystem based on childTriggerVerifier.noteValue
                        switch (childTriggerVerifier.noteValue)
                        {
                            case "Bad":
                                noteKeyController.badNoteParticleSystem.Play();
                                break;
                            case "Good":
                                noteKeyController.goodNoteParticleSystem.Play();
                                break;
                            case "Perfect":
                                noteKeyController.perfectNoteParticleSystem.Play();
                                break;
                        }
                        childTriggerVerifier.hasTriggered = false;
                        break;
                    }
                }
                
            }
        }
    }

}
