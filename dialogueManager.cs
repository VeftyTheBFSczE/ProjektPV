using System;
using UnityEngine;

[System.Serializable]
public struct DialogueSection
{
    public string[] dialogue;
    public bool endAfterDialogue;
    public BranchPoint branchPoint;
}

[System.Serializable]
public struct BranchPoint
{
    public string question;
    public DialogueSection[] answers;
}

[System.Serializable]
public class DialogueTree
{
    public DialogueSection[] sections;
}
