using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Coffee;
using Tools.Trees.Dialogue;
using UnityEngine.Events;

public class DialogueGatedOption : DialogueOptionNode
{
    [Min(0)] public int eventCheck;
}

