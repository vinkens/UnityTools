using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Xml;
using System.IO;
using System;
public class BMXMLTransfer
{
    static readonly string XmlDir = Application.dataPath + "/Fonts";
    static readonly string[] singleLineNodeNames = new string[] { "info", "common" };
    static readonly string[] TreeNodeNames = new string[] { "page", "char", "kerning" };
    [MenuItem("Assets/BMFont/Transfer XML")]
    static void CreateXml()
    {
        TextAsset[] assets = Selection.GetFiltered<TextAsset>(SelectionMode.Assets) as TextAsset[];
        if (assets.Length <= 0)
        {
            Debug.LogError("none text file selected");
            return;
        }
        TextAsset textAsset = assets[0];
        string content = textAsset.text;
        string docPath = XmlDir + "/" + textAsset.name + "Xml.fnt";
        if (File.Exists(docPath))
        {
            File.Delete(docPath);
        }
        //File.Create(docPath);
        XmlDocument document = new XmlDocument();
        document.AppendChild(document.CreateXmlDeclaration("1.0", "", ""));
        XmlNode fontNode = document.AppendChild(document.CreateElement("font"));

        string[] lines = content.Split('\n');
        Dictionary<string, List<string>> treeNodeStrDict = new Dictionary<string, List<string>>();
        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            string head = line.Split(' ')[0].Trim();
            if (Array.Exists(singleLineNodeNames, (x) => x.Equals(head)))
            {
                fontNode.AppendChild(CreateSingleLineNode(document, line));
            }
            else if (Array.Exists(TreeNodeNames, (x) => x.Equals(head)))
            {
                if (!treeNodeStrDict.TryGetValue(head, out List<string> lineList))
                {
                    lineList = new List<string>();
                    treeNodeStrDict.Add(head, lineList);
                }
                lineList.Add(line);
            }
        }

        for (int i = 0; i < TreeNodeNames.Length; i++)
        {
            if (treeNodeStrDict.ContainsKey(TreeNodeNames[i]))
            {
                fontNode.AppendChild(CreateTreeNode(document, treeNodeStrDict[TreeNodeNames[i]].ToArray(), TreeNodeNames[i] + "s"));
            }
        }

        try
        {
            document.Save(docPath);
            Debug.Log("生成xml文件成功：" + docPath);

        }
        catch (Exception e)
        {
            Debug.LogError("生成xml文件失败:" + e);
        }
    }

    static XmlNode CreateSingleLineNode(XmlDocument document, string lineText)
    {
        XmlNode node = null;
        XmlElement nodeElement = null;
        string[] elements = lineText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < elements.Length; i++)
        {
            string element = elements[i].Trim();
            if (i == 0)//head
            {
                node = document.CreateElement(element);
                nodeElement = node as XmlElement;
            }
            else
            {
                lineText.Replace("\"", "");
                string[] strs = element.Split('=');
                nodeElement.SetAttribute(strs[0], strs[1].Replace("\"", ""));
            }
        }
        return node;
    }

    static XmlNode CreateTreeNode(XmlDocument document, string[] lines, string parent)
    {
        XmlNode node = document.CreateElement(parent);
        XmlElement nodeElement = node as XmlElement;
        nodeElement.SetAttribute("count", lines.Length.ToString());

        for (int i = 0; i < lines.Length; i++)
        {
            node.AppendChild(CreateSingleLineNode(document, lines[i]));
        }
        return node;
    }
}
