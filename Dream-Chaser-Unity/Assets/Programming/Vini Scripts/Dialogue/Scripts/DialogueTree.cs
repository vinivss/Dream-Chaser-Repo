using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Tools.Trees.Dialogue
{
    [CreateAssetMenu (fileName = "Dialogue Tree", menuName = "Tools/Dialogue/New Dialogue Tree", order = 0)]
    public class DialogueTree : ScriptableObject
    {
        public DialogueNode RootNode;
        public DialogueNode.State treeState = DialogueNode.State.CUR;
        public List<DialogueNode> nodes = new List<DialogueNode>();

        public void DialogueStart()
        {
            RootNode.OnStart();
        }

#if UNITY_EDITOR
        public DialogueNode CreateNode(System.Type type)
        {
            DialogueNode node = ScriptableObject.CreateInstance(type) as DialogueNode;
            node.name = type.Name;
            node.GUID = GUID.Generate().ToString();

            Undo.RecordObject(this, "Dialogue Create Node");
            nodes.Add(node);

            if(!Application.isPlaying)
            {
                AssetDatabase.AddObjectToAsset(node, this);
            }
            Undo.RegisterCreatedObjectUndo(node, "Dialogue Create Node");
            AssetDatabase.SaveAssets();
            return node;
        }

        public void DeleteNode(DialogueNode node)
        {
            Undo.RecordObject(this, "Dialogue Delete Node");
            nodes.Remove(node);
            Undo.DestroyObjectImmediate(node);
            AssetDatabase.SaveAssets();
        }
        public void AddAction(DialogueNode parent, DialogueNode child)
        {
            if (child is DialogueActionNode)
            {
                DialogueRootNode rootNode = parent as DialogueRootNode;
                if (rootNode)
                {

                }
                DialogueChoiceNode choiceNode = parent as DialogueChoiceNode;
                if (choiceNode)
                {
                    Undo.RecordObject(choiceNode, "Dialogue add Child");
                    choiceNode.children.Add(child);
                    EditorUtility.SetDirty(choiceNode);
                }
                DialogueSpeechNode speechNode = parent as DialogueSpeechNode;
                if (speechNode)
                {
                    Undo.RecordObject(speechNode, "Dialogue add Action");
                    speechNode.DialogueActions.Add(child);
                    EditorUtility.SetDirty(speechNode);
                }

                DialogueOptionNode optionNode = parent as DialogueOptionNode;
                if (optionNode)
                {
                    Undo.RecordObject(optionNode, "Dialogue add Action");
                    optionNode.DialogueActions.Add(child);
                    EditorUtility.SetDirty(optionNode);
                }
            }
        }
        public void AddChild(DialogueNode parent, DialogueNode child)
        {
            DialogueRootNode rootNode = parent as DialogueRootNode;
            if(rootNode)
            {
                Undo.RecordObject(rootNode, "Dialogue Add Child");
                rootNode.child = child;
                EditorUtility.SetDirty(rootNode);
            }
            DialogueChoiceNode choiceNode = parent as DialogueChoiceNode;
            if(choiceNode)
            {
                    Undo.RecordObject(choiceNode, "Dialogue add Action");
                    choiceNode.DialogueActions.Add(child);
                    EditorUtility.SetDirty(choiceNode);
            }
            DialogueSpeechNode speechNode = parent as DialogueSpeechNode;
            if(speechNode)
            {
                    Undo.RecordObject(speechNode, "Dialogue add Child");
                    speechNode.child = child;
                    EditorUtility.SetDirty(speechNode);
            }

            DialogueOptionNode optionNode = parent as DialogueOptionNode;
            if(optionNode)
            {
                    Undo.RecordObject(optionNode, "Dialogue add Child");
                    optionNode.child = child;
                    EditorUtility.SetDirty(optionNode);
            }
        }

        public void KillChild(DialogueNode parent, DialogueNode child)
        {
            DialogueRootNode rootNode = parent as DialogueRootNode;
            if (rootNode)
            {
                Undo.RecordObject(rootNode, "Dialogue Add Child");
                rootNode.child = null;
                EditorUtility.SetDirty(rootNode);
            }
            DialogueChoiceNode choiceNode = parent as DialogueChoiceNode;
            if (choiceNode)
            {
                Undo.RecordObject(choiceNode, "Dialogue add Child");
                choiceNode.children.Remove(child);
                EditorUtility.SetDirty(choiceNode);
            }
            DialogueSpeechNode speechNode = parent as DialogueSpeechNode;
            if (speechNode)
            {
                Undo.RecordObject(speechNode, "Dialogue add Child");
                speechNode.child = null;
                EditorUtility.SetDirty(speechNode);
            }
        }


#endif
        public List<DialogueNode> GetChildren(DialogueNode parent)
        {
            List<DialogueNode> children = new List<DialogueNode>();

            DialogueRootNode rootNode = parent as DialogueRootNode;
            if (rootNode && rootNode.child != null)
            {
                children.Add(rootNode.child);
            }
            DialogueChoiceNode choiceNode = parent as DialogueChoiceNode;
            if (choiceNode && choiceNode.children != null)
            {
                return choiceNode.children;
            }
            DialogueSpeechNode speechNode = parent as DialogueSpeechNode;
            if (speechNode && speechNode.child != null)
            {
                children.Add(speechNode.child);
            }
            DialogueOptionNode optionNode = parent as DialogueOptionNode;
            if (optionNode && optionNode.child != null)
            {
                children.Add(optionNode.child);
            }
            return children;
        }

        public List<DialogueNode> GetActions(DialogueNode parent)
        {
            List<DialogueNode> Actions = new List<DialogueNode>();

            DialogueChoiceNode choiceNode = parent as DialogueChoiceNode;
            if (choiceNode && choiceNode.children != null)
            {
                return choiceNode.DialogueActions;
            }
            DialogueSpeechNode speechNode = parent as DialogueSpeechNode;
            if (speechNode && speechNode.child != null)
            {
                return speechNode.DialogueActions;
            }
            DialogueOptionNode optionNode = parent as DialogueOptionNode;
            if (optionNode && optionNode.child != null)
            {
                return optionNode.DialogueActions;
            }
            return Actions;
        }    

        public void Traverse(DialogueNode node, System.Action<DialogueNode> visitor)
        {
            if(node)
            {
                visitor.Invoke(node);
                var children = GetChildren(node);
                children.ForEach((n) => Traverse(n,visitor));   
            }
        }

        public DialogueTree Clone()
        {
            DialogueTree tree = Instantiate(this);
            tree.RootNode = tree.RootNode.Clone();
            tree.nodes = new List<DialogueNode>();
            Traverse(tree.RootNode, (n) => tree.nodes.Add(n));
            return tree;
        }

    }
}
