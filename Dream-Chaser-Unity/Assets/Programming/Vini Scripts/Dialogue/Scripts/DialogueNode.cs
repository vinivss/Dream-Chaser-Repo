using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using TMPro;
using UnityEngine;
namespace Tools.Trees.Dialogue
{
    public abstract class DialogueNode : ScriptableObject
    {
        public enum State
        {
            CUR,
            FIN,
            NXT
        }

        [HideInInspector] public bool started = false;
        [HideInInspector] public string GUID;
        [HideInInspector] public Vector2 position;
        [HideInInspector] public State state = State.CUR;
        [Header("Text Attributes")]
        [TextArea] public string Speaker;
        [TextArea]public string Dialogue;
        [Space]
        [Header("UI Editors")]
        [Tooltip("Image displayed as character is talking")]
        [DataMember]public GameObject SceneLayout;



        public virtual DialogueNode Clone()
        {
            return Instantiate(this);
        }
        public abstract void OnStart();
        public abstract void EndNode();
    }
}
