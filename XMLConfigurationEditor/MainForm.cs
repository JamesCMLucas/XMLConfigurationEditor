using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XMLConfigurationLib;

namespace XMLConfigurationEditor
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// The handler class for the xml and xsd files
        /// </summary>
        private cXMLHandler xmlHandler;

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            xmlHandler = new cXMLHandler();
        }

        private void LoadFileButton_Click(object sender, EventArgs e)
        {
            // create an OpenFileDialog
            OpenFileDialog dialog = new OpenFileDialog();

            // set it's filter to only look at xml files
            dialog.Filter = "XML files (*.xml)|*.xml";

            // show it
            DialogResult dialogResult = dialog.ShowDialog();
            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            // get the path from the dialog
            string filePath = dialog.FileName;
            
            // create a cXmlHandler
            cXMLHandler xmlHandler = new cXMLHandler();
            string xmlResult = "";

            // try to load the file
            try
            {
                xmlResult = xmlHandler.LoadXMLFileToString(filePath);
            }
            catch (System.Exception ex)
            {
                string exString = "Error: " + ex.Message;
                MessageBox.Show(exString);
                return;
            }

            MainTextBox.Clear();
            MainTextBox.Text = xmlResult;
        }

        private void SaveFileButton_Click(object sender, EventArgs e)
        {

        }

        private void buttonTestLoad_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\GitHub\\XMLConfigurationEditor\\Resource\\books.xml";

            string xmlResult = "";

            // try to load the file
            try
            {
                xmlResult = xmlHandler.LoadXMLFileToString(filePath);
            }
            catch (System.Exception ex)
            {
                string exString = "Error: " + ex.Message;
                MessageBox.Show(exString);
                return;
            }

            MainTextBox.Clear();
            MainTextBox.Text = xmlResult;

            List<string> schemaWarnings = xmlHandler.GetWarnings();
            if (schemaWarnings.Count != 0)
            {
                for (int idxWarning = 0; idxWarning < schemaWarnings.Count; idxWarning++)
                {
                    string warning = schemaWarnings[idxWarning] + " Show Next Warning?";
                    string caption = "Warning " + Convert.ToString(idxWarning) + " of " + Convert.ToString(schemaWarnings.Count);
                    DialogResult dialogResult = MessageBox.Show(warning, caption, MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        break;
                    }
                }
            }
        }

        private void buttonTestSave_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\GitHub\\XMLConfigurationEditor\\Resource\\booksSave.xml";

            // try to load the file
            try
            {
                xmlHandler.SaveStringAsXMLFile(filePath, MainTextBox.Text);
            }
            catch (System.Exception ex)
            {
                string exString = "Error: " + ex.Message;
                MessageBox.Show(exString);
                return;
            }
        }

        private void buttonLoadSchemaTest_Click(object sender, EventArgs e)
        {
            string filePath = "C:\\GitHub\\XMLConfigurationEditor\\Resource\\XMLSchema.xsd";

            string xsdResult = "";

            // try to load the file
            try
            {
                xsdResult = xmlHandler.LoadSchemaFromFile(filePath);
            }
            catch (System.Exception ex)
            {
                string exString = "Error: " + ex.Message;
                MessageBox.Show(exString);
                return;
            }

            MainTextBox.Clear();
            MainTextBox.Text = xsdResult;
        }
    }
}
