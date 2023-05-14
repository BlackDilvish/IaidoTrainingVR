using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingController : MonoBehaviour
{
    public enum TrainingType
    {
        NukitsukeKiritsuke,
        Mae
    }

    [SerializeField]
    private Transform playerPosition;

    [SerializeField]
    private TrainingStep kissakiStepPrefab;
    [SerializeField]
    private TrainingStep rightHandStepPrefab;

    [SerializeField]
    private Text text;

    public TrainingType trainingType;
    private ITraining currentTraining;

    void Update()
    {
        if (this.currentTraining != null)
        {
            this.currentTraining.Update();

            if (this.currentTraining.IsFinished())
            {
                this.text.text = "Finished: " + this.trainingType.ToString();
                this.currentTraining = null;
            }
        }
    }

    public void StartTraining()
    {
        if (this.currentTraining != null)
        {
            this.currentTraining.Clear();
        }

        this.text.text = "Current training sequence: " + this.trainingType.ToString();
        switch (this.trainingType)
        {
            case TrainingType.NukitsukeKiritsuke:
                this.currentTraining = new NukitsukeKiritsukeTraining(playerPosition, kissakiStepPrefab, rightHandStepPrefab);
                break;
            default:
                break;
        }
    }
}
