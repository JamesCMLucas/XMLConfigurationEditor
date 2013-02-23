using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using XMLConfigurationLib;
using System.IO;

namespace NUnit_Tests
{

    public class cExceptionThrower
    {
        public void ThrowAE()
        {
            throw new ArgumentException();
        }

        public void ThrowSE()
        {
            throw new SystemException();
        }
    }


    /// <summary>
    /// NUnit Test class for cXMLHandler
    /// </summary>
    [TestFixture]
    public class cXMLHandlerTest
    {
        public const string XmlFileNameGood = @"..\..\TestDocs\TestFileGood.xml";
        public const string XmlFileNameGoodSave = @"..\..\TestDocs\TestFileGoodSave.xml";
        public const string XmlFileNameGoodValidatedSave = @"..\..\TestDocs\TestFileGoodValidatedSave.xml";
        public const string XmlFileNameBadValidation = @"..\..\TestDocs\TestFileBadValidation.xml";
        public const string XmlFileNameBad = @"..\..\TestDocs\TestFileBad.xml";
        public const string XsdFileName = @"..\..\TestDocs\TestSchema.xsd";

        public const string XmlDocGood =
@"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
<coolguy>
  <sunglasses>RayBan</sunglasses>
  <frostedtips>1000</frostedtips>
</coolguy>";

        public const string XmlDocBad =
@"<?xml version=""1.0"" encoding=""ISO-8859-1""?>
<coolguy>
  <sunglasses>RayBan</sunglasses>
  <pokemon>1000</pokemon>
</coolguy>";


        /// <summary>
        /// Tests the Xml loading function
        /// </summary>
        [Test]
        public void LoadGoodXMLFileToString()
        {
            cXMLHandler handler = new cXMLHandler();
            string doc = handler.LoadXMLFileToString(XmlFileNameGood);
            Assert.AreEqual(doc.Trim(), XmlDocGood.Trim());
        }

        /// <summary>
        /// Tests a successful xml load with schema validation
        /// </summary>
        [Test]
        public void LoadGoodXMLFileWithSchema()
        {
            cXMLHandler handler = new cXMLHandler();
            string schema = handler.LoadSchemaFromFile(XsdFileName);
            string goodDoc = handler.LoadXMLFileToString(XmlFileNameGood);
            List<string> warnings = handler.GetWarnings();
            Assert.IsTrue(warnings.Count == 0);
        }

        /// <summary>
        /// Test that a system exception is thrown when an invalid xml file is loaded
        /// </summary>
        [Test]
        [ExpectedException(typeof(System.Exception))]
        public void LoadBadXMLFileWithSchema()
        {
            using (System.IO.StreamWriter xmlBadFile = new System.IO.StreamWriter(XmlFileNameBad))
            {
                xmlBadFile.WriteLine(XmlDocBad);
            }
            cXMLHandler handler = new cXMLHandler();
            string schema = handler.LoadSchemaFromFile(XsdFileName);
            string badDoc = handler.LoadXMLFileToString(XmlFileNameBad);
        }

        /// <summary>
        /// Tests saving the contents of a good xml file
        /// </summary>
        [Test]
        public void SaveGoodStringAsXMLFile()
        {
            cXMLHandler handler = new cXMLHandler();
            handler.SaveStringAsXMLFile(XmlFileNameGoodSave, XmlDocGood);
        }

        /// <summary>
        /// Tests saving with validation of good stuff
        /// </summary>
        [Test]
        public void SaveGoodValidatedStringAsXMLFile()
        {
            cXMLHandler handler = new cXMLHandler();
            string schema = handler.LoadSchemaFromFile(XsdFileName);
            handler.SaveStringAsXMLFile(XmlFileNameGoodValidatedSave, XmlDocGood);
        }

        /// <summary>
        /// Tests that a string that fails against a schema isn't saved
        /// </summary>
        [Test]
        [ExpectedException(typeof(System.Exception))]
        public void SaveBadValidatedStringAsXMLFile()
        {
            if (File.Exists(XmlFileNameBadValidation))
            {
                File.Delete(XmlFileNameBadValidation);
            }
            cXMLHandler handler = new cXMLHandler();
            string schema = handler.LoadSchemaFromFile(XsdFileName);
            handler.SaveStringAsXMLFile(XmlFileNameBadValidation, XmlDocBad);
            if (File.Exists(XmlFileNameBadValidation))
            {
                File.Delete(XmlFileNameBadValidation);
            }
        }
    }
}
