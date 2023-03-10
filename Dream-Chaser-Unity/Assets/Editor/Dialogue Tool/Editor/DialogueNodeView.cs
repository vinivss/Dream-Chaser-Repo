using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;
using UnityEditor;

namespace Tools.Trees.Dialogue
{
    public class DialogueNodeView : UnityEditor.Experimental.GraphView.Node
    {
        public Action<DialogueNodeView> OnNodeSelected;
        public DialogueNode node;
        public Port input;
        public Port output;
        public Port actionout;
        public Port actionin;

        public DialogueNodeView(DialogueNode node) : base("Assets/Editor/Dialogue Tool/Editor/DialogueNodeView.uxml")
        {
            this.node = node;
            this.title = node.name;
            this.viewDataKey = node.GUID;

            style.left = node.position.x;
            style.top = node.position.y;

            CreateInputPorts();
            CreateActionInputPorts();
            CreateaActionOutputPorts();
            CreateOutputPorts();
          
           
            SetupClasses();

            TextField dialoguebox = this.Q<TextField>("Dialogue");
            dialoguebox.bindingPath = "Dialogue";
            dialoguebox.Bind(new SerializedObject(node));

            Label Speaker = this.Q<Label>("Speaker");
            Speaker.bindingPath = "Speaker";
            Speaker.Bind(new SerializedObject(node));
          
        }



        private void SetupClasses()
        {
            if(node is DialogueRootNode)
            {
                AddToClassList("root");
            }
            else if(node is DialogueSpeechNode)
            {
                AddToClassList("speech");
            }
            else if (node is DialogueEndNode)
            {
                AddToClassList("end");
            }
            else if (node is DialogueChoiceNode)
            {
                AddToClassList("choice");
            }
            else if (node is DialogueOptionNode)
            {
                AddToClassList("option");
            }
            else if(node is DialogueActionNode)
            {
                AddToClassList("action");
            }
        }

        private void CreateInputPorts()
        {
            if(node is DialogueEndNode)
            {
                input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            }
            else if(node is DialogueRootNode) { }
            if(node is DialogueChoiceNode)
            {
                input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            }
            if (node is DialogueSpeechNode)
            {
                input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));
            }
            if (node is DialogueOptionNode)
            {
                input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Single, typeof(bool));
            }
            if (input != null)
            {
                input.portName = "";
                input.style.flexDirection = FlexDirection.Row;
                input.style.alignSelf = Align.FlexStart;
                input.portColor = Color.red;
                inputContainer.Add(input);
            }
        }
        private void CreateOutputPorts()
        {

            
            if (node is DialogueRootNode)
            {
                output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
            }
             if (node is DialogueEndNode)
            {
            }
           
            if (node is DialogueChoiceNode)
            {
                output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Multi, typeof(bool));
            }
            if (node is DialogueSpeechNode)
            {
                output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
            }

            if (node is DialogueOptionNode)
            {
                output = InstantiatePort(Orientation.Horizontal, Direction.Output, Port.Capacity.Single, typeof(bool));
            }

            if(output != null)
            {
                output.portName = "";
                output.style.flexDirection = FlexDirection.Row;
                output.style.alignSelf = Align.FlexEnd;
                output.portColor = Color.blue;
                outputContainer.Add(output);
            }
        }
        private void CreateActionInputPorts()
        {
            if (node is DialogueRootNode)
            {
            }
            if(node is DialogueEndNode)
            {
            }
            if (node is DialogueChoiceNode)
            {
                actionin = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Multi, typeof(bool));
            }
            if (node is DialogueSpeechNode)
            {
                actionin = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Multi, typeof(bool));
            }

            if (node is DialogueOptionNode)
            {
                actionin = InstantiatePort(Orientation.Vertical, Direction.Input, Port.Capacity.Multi, typeof(bool));
            }
            if(node is DialogueActionNode)
            {
            }
            if(actionin != null)
            {
                actionin.portName = "";
                actionin.style.flexDirection = FlexDirection.Row;
                actionin.style.alignSelf = Align.FlexEnd;
                actionin.portColor = Color.magenta;
                actionin.Add(output);
            }
        }
        private void CreateaActionOutputPorts()
        {
            if (node is DialogueRootNode)
            {
            }
            if (node is DialogueEndNode)
            {
            }
            if (node is DialogueChoiceNode)
            {
               
            }
            if (node is DialogueSpeechNode)
            {

            }

            if (node is DialogueOptionNode)
            {
              
            }
            if(node is DialogueActionNode)
            {
                actionout = InstantiatePort(Orientation.Vertical, Direction.Output,Port.Capacity.Single, typeof(bool));
            }

            if (actionout != null)
            {
                actionout.portName = "";
                actionout.style.flexDirection = FlexDirection.Row;
                actionout.style.alignSelf = Align.FlexEnd;
                actionout.portColor = Color.yellow;
                actionout.Add(output);
            }
        }
        

        public override void SetPosition(Rect newPos)
        {
            base.SetPosition(newPos);
            Undo.RecordObject(node, "Dialogue Tree Set Pos");
            node.position.x = newPos.xMin;
            node.position.y = newPos.yMin;
            EditorUtility.SetDirty(node);
        }

        public override void OnSelected()
        {
            base.OnSelected();
            if(OnNodeSelected != null)
            {
                OnNodeSelected.Invoke(this);
            }
        }

        internal void SortChildren()
        {
            DialogueChoiceNode choiceNode = node as DialogueChoiceNode;

            if(choiceNode && choiceNode.children.Count > 0)
            {
                choiceNode.children.Sort(SortByVerticalPosition);
            }
        }

        private int SortByVerticalPosition(DialogueNode top, DialogueNode bot)
        {
            return top.position.y < bot.position.y ? -1 : 1;
        }

        internal void UpdateState()
        {
            RemoveFromClassList("running"); 
            RemoveFromClassList("next");
            RemoveFromClassList("finished");

            if(Application.isPlaying)
            {
                switch(node.state)
                {
                    case DialogueNode.State.CUR:
                        AddToClassList("running");
                        break;
                    case DialogueNode.State.FIN:
                        AddToClassList("finished");
                        break;
                    case DialogueNode.State.NXT:
                        AddToClassList("next");
                        break;
                }
            }

        }
    }
}
