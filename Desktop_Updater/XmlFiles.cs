using System;
using System.IO;
using System.Xml;

namespace WBPlatform.InstallFinaliser
{
	/// <summary>
	/// XmlFiles ��ժҪ˵����
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
		/// ����һ���ڵ��xPath���ʽ������һ���ڵ�
		/// </summary>
		/// <param name="node"></param>
		/// <returns></returns>
		public XmlNode FindNode(string xPath)
		{
			XmlNode xmlNode = SelectSingleNode(xPath);
			return xmlNode;
		}
		/// <summary>
		/// ����һ���ڵ��xPath���ʽ������ֵ
		/// </summary>
		/// <param name="xPath"></param>
		/// <returns></returns>
		public string GetNodeValue(string xPath)
		{
			XmlNode xmlNode = SelectSingleNode(xPath);
			return xmlNode.InnerText;
		}
		/// <summary>
		/// ����һ���ڵ�ı��ʽ���ش˽ڵ��µĺ��ӽڵ��б�
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
