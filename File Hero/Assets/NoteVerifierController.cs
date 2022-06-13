using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NoteVerifierController : MonoBehaviour
{
    public NoteKeyController[] noteKeyControllers;
    public RuntimeText runtimeText;
    //create list to store time between each note
    private List<float> timesOnA, timesOnB, timesOnC, timesOnD, timesOnE;
    private float timeBetweenA, timeBetweenB, timeBetweenC, timeBetweenD, timeBetweenE;
    private bool isVerifierA = false, isVerifierB = false, isVerifierC = false, isVerifierD = false, isVerifierE = false;
    // Start is called before the first frame update
    void Start()
    {
        timesOnA = new List<float>();
        timesOnB = new List<float>();
        timesOnC = new List<float>();
        timesOnD = new List<float>();
        timesOnE = new List<float>();
        //runtimeText.WriteString();
    }

    // Update is called once per frame
    void Update()
    {
        //store time that has elapsed 
        float timeElapsed = Time.time;
        if (isVerifierA)
        {
            isVerifierA = false;
            //if timesOnA is not empty, add time between each note to the list
            if (timesOnA.Count > 0)
            {
                if(timeElapsed - timeBetweenA > 0.15f){
                    timesOnA.Add(timeElapsed - timeBetweenA);
                    //Debug.Log(timeElapsed - timeBetweenA);
                    runtimeText.WriteString("" + (timeElapsed - timeBetweenA));
                }else{
                    timesOnA.Add(0.12f);
                    //Debug.Log(timeElapsed - timeBetweenA);
                    runtimeText.WriteString("" + 0.12f);
                }
                timeBetweenA = timesOnA[timesOnA.Count - 1] + timeBetweenA;
            }
            else
            {
                runtimeText.ClearFile();
                timesOnA.Add(timeElapsed);
                timeBetweenA = timeElapsed;
                //Debug.Log(timeElapsed);
                runtimeText.WriteString("" + timeElapsed);
            }
        }
    }

    void OnVerifier_A(InputValue value) {
        KeyPressedVerifier(value.Get<float>(),noteKeyControllers[0]);
        //runtimeText.WriteString();
        isVerifierA = true;
        //Print data on timesOnA
        /*foreach (float time in timesOnA)
        {
            Debug.Log(time);
        }*/
    }
    void OnVerifier_B(InputValue value) {
        KeyPressedVerifier(value.Get<float>(),noteKeyControllers[1]);
    }
    void OnVerifier_C(InputValue value) {
        KeyPressedVerifier(value.Get<float>(),noteKeyControllers[2]);
        //runtimeText.ReadString();
        isVerifierC = true;
    }
    void OnVerifier_D(InputValue value) {
        KeyPressedVerifier(value.Get<float>(),noteKeyControllers[3]);
        //runtimeText.ReadString();
        isVerifierD = true;
    }
    void OnVerifier_E(InputValue value) {
        KeyPressedVerifier(value.Get<float>(),noteKeyControllers[4]);
        //runtimeText.WriteString();
        isVerifierE = true;
    }

    private void KeyPressedVerifier(float inputVal, NoteKeyController noteKeyController) {
        if(inputVal > 0){
            noteKeyController.noteVerifierPressed = true;
            /*isVerifierA = true;
            isVerifierB = true;
            isVerifierC = true;
            isVerifierD = true;
            isVerifierE = true;*/
        }
        else{
            noteKeyController.noteVerifierPressed = false;
            noteKeyController.isEnabled = true;
        }
            
        //Debug.Log("KeyState: " + noteKeyController.noteVerifierPressed);
    }
}
