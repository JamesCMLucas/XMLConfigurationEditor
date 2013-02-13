using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.IO;

namespace XMLConfigurationLib
{
    /// <summary>
    /// Loads and saves xml and xsd files
    /// </summary>
    public class cXMLHandler
    {
        private XmlSchema mSchema;
        private bool mbSchemaIsLoaded;
        public List<string> mWarningsList;

        /// <summary>
        /// Constructor
        /// </summary>
        public cXMLHandler()
        {
            mSchema = new XmlSchema();
            mWarningsList = new List<string>();
            mbSchemaIsLoaded = false;
        }

        /// <summary>
        /// Loads a schema from a file
        /// Use this schema in all future xml loading / saving for validation
        /// 
        /// Throws exceptions for:
        ///                           Bad file extension
        ///                           File doesn't exist
        ///                           Loading error
        /// </summary>
        /// <param name="filePath">file name of the schema to load</param>
        /// <returns>The xsd file contents as a string</returns>
        public string LoadSchemaFromFile(string filePath)
        {
            mWarningsList.Clear();
            // check that it's an xml file
            if (Path.GetExtension(filePath) != ".xsd")
            {
                throw new Exception("Bad File Extension");
            }
            // check that the file exists
            if (!File.Exists(filePath))
            {
                throw new Exception("File Doesn't Exist");
            }

            string xsdContents = "";

            try
            {
                XmlTextReader reader = new XmlTextReader(filePath);
                mSchema = XmlSchema.Read(reader, ValidationCallback);

                MemoryStream memStream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                mSchema.Write(writer);
                writer.Flush();
                memStream.Flush();
                memStream.Position = 0;
                // read the MemoryStream contents to a StreamReader
                StreamReader streamReader = new StreamReader(memStream);

                // get the formatted text from the stream reader
                xsdContents = streamReader.ReadToEnd();
                mbSchemaIsLoaded = true;
            }
            catch (System.Exception ex)
            {
                string exString = "Loading Error: " + ex.Message;
                throw new Exception(exString);
            }

            return xsdContents;
        }

        private void ValidationCallback(object sender, ValidationEventArgs args)
        {

            if (args.Severity == XmlSeverityType.Warning)
            {
                mWarningsList.Add(args.Message);
            }
            else if (args.Severity == XmlSeverityType.Error)
            {
                throw args.Exception;
            }
        }

        /// <summary>
        /// Get the list of warnings generated from the last load or save
        /// </summary>
        /// <returns>list of strings</returns>
        public List<string> GetWarnings()
        {
            return mWarningsList;
        }

        /// <summary>
        /// Forgets the last loaded schema
        /// No more validation on xml loading / saving
        /// </summary>
        public void ForgetSchema()
        {
            mSchema = new XmlSchema();
            mbSchemaIsLoaded = false;
        }

        /// <summary>
        /// Loads an xml file
        /// Throws exceptions for:
        ///                           Bad file extension
        ///                           File doesn't exist
        ///                           Loading error
        /// </summary>
        /// <param name="filePath">Path to the xml document</param>
        /// <returns>The xml file contents as a string</returns>
        public string LoadXMLFileToString(string filePath, bool bDoValidation = true)
        {
            mWarningsList.Clear();

            // check that it's an xml file
            if (Path.GetExtension(filePath) != ".xml")
            {
                throw new Exception("Bad File Extension");
            }
            // check that the file exists
            if (!File.Exists(filePath))
            {
                throw new Exception("File Doesn't Exist");
            }

            String xmlContents = "";

            try
            {
                MemoryStream memStream = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(memStream, Encoding.Unicode);
                writer.Formatting = Formatting.Indented;
                XmlDocument document = new XmlDocument();

                if (bDoValidation && mbSchemaIsLoaded)
                {
                    XmlTextReader textReader = new XmlTextReader(filePath);
                    XmlReaderSettings settings = new XmlReaderSettings();
                    settings.ValidationType = ValidationType.Schema;
                    settings.ValidationFlags |= XmlSchemaValidationFlags.ReportValidationWarnings;
                    settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallback);
                    settings.Schemas.Add(mSchema);
                    XmlReader reader = XmlReader.Create(textReader, settings);
                    //XmlReader reader = XmlReader.Create(textReader, new XmlReaderSettings());
                    document.Load(reader);
                    //document.Schemas.Add(mSchema);
                    //document.Validate(ValidationCallback, document);
                }
                else
                {
                    // load the file into the XmlDocument
                    document.Load(filePath);
                }
                
                // write contents to the writer
                document.WriteContentTo(writer);
                writer.Flush();
                memStream.Flush();

                // move back to the beginning position to read
                memStream.Position = 0;

                // read the MemoryStream contents to a StreamReader
                StreamReader streamReader = new StreamReader(memStream);

                // get the formatted text from the stream reader
                xmlContents = streamReader.ReadToEnd();
            }

            catch (System.Exception ex)
            {
                string exString = "Loading Error: " + ex.Message;
                throw new Exception(exString);
            }

            return xmlContents;
        }

        /// <summary>
        /// Saves a given string to file as xml
        /// Throws exceptions for:
        ///                           Saving error
        /// </summary>
        /// <param name="filePath">File name to save as</param>
        /// <param name="xmlContents">Xml Contents - full file as a string</param>
        public void SaveStringAsXMLFile(string filePath, string xmlContents, bool bDoValidation = true)
        {
            mWarningsList.Clear();
            try
            {
                XmlDocument document = new XmlDocument();
                document.LoadXml(xmlContents);

                if (bDoValidation && mbSchemaIsLoaded)
                {
                    document.Schemas.Add(mSchema);
                    document.Validate(ValidationCallback, document);
                    document.Save(filePath);
                }
                else
                {
                    document.Save(filePath);
                }


            }
            catch (System.Exception ex)
            {
                string exString = "Saving error: " + ex.Message;
                throw new Exception(exString);
            }
        }
    }
}
