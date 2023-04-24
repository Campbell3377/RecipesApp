using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.XPath;

namespace RecipesApp
{
    public partial class XMLFileUtils : System.Web.UI.Page
    {
        public class XMLManipulation
        {
            private string filePath;

            public XMLManipulation(string filePath)
            {
                this.filePath = filePath;
            }

            public XDocument LoadXmlFile()
            {
                return XDocument.Load(filePath);
            }

            private void SaveXmlFile(XDocument xmlDoc)
            {
                xmlDoc.Save(filePath);
            }

            public IEnumerable<XElement> GetAllElements(string elementName)
            {
                var xmlDoc = LoadXmlFile();
                return xmlDoc.Descendants(elementName);
            }

            public void AddElement(string parentElementName, string elementName, string elementValue)
            {
                var xmlDoc = LoadXmlFile();
                //Gets the parent element
                var parentElement = xmlDoc.Descendants(parentElementName).FirstOrDefault();

                //Add the new element to the parent element if it is found
                if (parentElement != null)
                {
                    XElement newElement = new XElement(elementName, elementValue);
                    parentElement.Add(newElement);
                    SaveXmlFile(xmlDoc);
                }
                else
                {
                    Console.WriteLine($"Parent element '{parentElementName}' not found.");
                }
            }

            //This function is used from my A7 assignment
            public XElement[] FindElements(string pathExpression)
            {
                List<XElement> matchingElements = new List<XElement>();

                //Set up the process to find the matching path elements
                XPathDocument xdoc = new XPathDocument(filePath);
                XPathNavigator xpdoc = xdoc.CreateNavigator();
                XPathNodeIterator xset = xpdoc.Select(pathExpression);

                //Go through the file and add the matching elements to the list
                while (xset.MoveNext())
                {
                    XElement element = XElement.Parse(xset.Current.OuterXml);
                    matchingElements.Add(element);
                }

                //Convert the list to an array and return
                return matchingElements.ToArray();
            }

            //Delete an element given an element name and value
            public void DeleteElement(string elementName, string elementValue)
            {
                var xmlDoc = LoadXmlFile();

                //Gets all the elements that share the same name and value
                var elementsToRemove = xmlDoc.Descendants(elementName)
                                      .Where(e => e.Value == elementValue)
                                      .ToList();

                //Remove the elements from the XML document
                foreach (var element in elementsToRemove)
                {
                    element.Remove();
                }

                SaveXmlFile(xmlDoc);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SearchElementsButton_Click(object sender, EventArgs e)
        {
            XMLManipulation xmlUtil = new XMLManipulation(XmlFileName.Text);

            string xmlPath = xmlPathExpression.Text;
            XElement[] searchedElements = xmlUtil.FindElements(xmlPath);

            //This shares similarity to my A7 assignment
            StringBuilder sb = new StringBuilder();
            int count = 1;

            //Format the html to list each XElement one by one
            foreach (XElement element in searchedElements)
            {
                sb.Append(count + ". ");
                sb.Append(element.ToString());
                sb.Append("<br />");
                count++;
            }

            SearchResult.Text = sb.ToString();
        }

        protected void AddElementButton_Click(object sender, EventArgs e)
        {
            XMLManipulation xmlUtil = new XMLManipulation(XmlFileName.Text);

            string parentName = parentElementName.Text;
            string elementName = addElementName.Text;
            string elementValue = addElementValue.Text;

            xmlUtil.AddElement(parentName, elementName, elementValue);

            AddResult.Text = xmlUtil.LoadXmlFile().ToString();
        }

        protected void DelElementButton_Click(object sender, EventArgs e)
        {
            XMLManipulation xmlUtil = new XMLManipulation(XmlFileName.Text);

            string elementName = delElementName.Text;
            string elementValue = delElementValue.Text;

            xmlUtil.DeleteElement(elementName, elementValue);

            DelResult.Text = xmlUtil.LoadXmlFile().ToString();
        }
    }
}