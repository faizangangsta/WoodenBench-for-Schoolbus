using System;
using System.IO;
using System.Xml;

namespace WBPlatform.InstallFinaliser
{
	/// <summary>
	/// XmlFiles 的摘要说明。
	/// </summary>
	public class XmlFiles : XmlDocument
	{
		private string _xmlFileName;
		public string XmlFileName
		{
			set { XmlFileName1 = value; }
			get { return XmlFileName1; }
		}

		public string XmlFileName1 { get => _xmlFileName; set => _xmlFileName = value; }

		public XmlFiles(string xmlFile)
		{
			XmlFileName = xmlFile;
			Load(xmlFile);
		}
		/// <summary>
		/// 给定一个节点的xPath表达式并返回一个节点
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public XmlNode FindNode(string xPath)
		{
			XmlNode xmlNode = SelectSingleNode(xPath);
			return xmlNode;
		}
		/// <summary>
		/// 给定一个节点的xPath表达式返回其值
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public string GetNodeValue(string xPath)
		{
			XmlNode xmlNode = SelectSingleNode(xPath);
			return xmlNode.InnerText;
		}
		/// <summary>
		/// 给定一个节点的表达式返回此节点下的孩子节点列表
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public XmlNodeList GetNodeList(string xPath)
		{
			XmlNodeList nodeList = SelectSingleNode(xPath).ChildNodes;
			return nodeList;
		}
	}
}
