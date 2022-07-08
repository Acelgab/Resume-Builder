using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace Resume_Builder
{
  
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblBASIC.Hide();lblName.Hide();txtbxFullName.Hide();lblAddress.Hide(); 
            txtbxAddress.Hide(); lblEmail.Hide(); txtbxEmail.Hide(); lblContact.Hide();
            txtbxContact.Hide(); lblPROFESSIONAL.Hide(); btnAddExp.Hide(); lblCompany.Hide();
            txtbxCompany.Hide(); lblDates.Hide(); txtbxDates.Hide(); lblJob.Hide();
            txtbxJob.Hide(); lblSummary.Hide(); txtbxSummary.Hide(); lblCompany2.Hide();
            txtbxCompany2.Hide(); lblDates2.Hide(); txtbxDates2.Hide(); lblJob2.Hide();
            txtbxJob2.Hide(); lblSummary2.Hide(); txtbxSummary2.Hide(); lblCompany3.Hide();
            txtbxCompany3.Hide(); lblDates3.Hide(); txtbxDates3.Hide(); lblJob3.Hide();
            txtbxJob3.Hide(); lblSummary3.Hide(); txtbxSummary3.Hide(); lblEDUC.Hide();
            lblSchool.Hide(); txtbxSchool.Hide(); lblGradDate.Hide(); txtbxGradDate.Hide();
            lblDegree.Hide();txtbxDegree.Hide(); lblGPA.Hide(); txtbxGPA.Hide(); btnAddExp2.Hide();
            lblSurname.Hide(); lblFirstName.Hide();lblMiddle.Hide(); txtbxFirst.Hide(); btnSave.Hide();
            txtbxMiddle.Hide(); rchtxtbxRead.Hide();

        }

        private void txtbxCompany_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void btnBasicInfo_Click(object sender, EventArgs e)
        {
            lblBASIC.Show(); lblName.Show(); txtbxFullName.Show(); lblAddress.Show();
            txtbxAddress.Show(); lblEmail.Show(); txtbxEmail.Show(); lblContact.Show();
            txtbxContact.Show(); txtbxFirst.Show(); txtbxMiddle.Show(); lblSurname.Show();lblMiddle.Show();
            lblFirstName.Show();
        }

        private void btnProfessional_Click(object sender, EventArgs e)
        {
            lblPROFESSIONAL.Show(); btnAddExp.Show(); lblCompany.Show();
            txtbxCompany.Show(); lblDates.Show(); txtbxDates.Show(); lblJob.Show();
            txtbxJob.Show(); lblSummary.Show(); txtbxSummary.Show(); 
        }

        private void btnAddExp_Click(object sender, EventArgs e)
        {
            lblCompany2.Show();
            txtbxCompany2.Show(); lblDates2.Show(); txtbxDates2.Show(); lblJob2.Show();
            txtbxJob2.Show(); lblSummary2.Show(); txtbxSummary2.Show(); btnAddExp2.Show();
            btnAddExp.Hide();
        }

        private void btnAddExp2_Click(object sender, EventArgs e)
        {
            lblCompany3.Show();
            txtbxCompany3.Show(); lblDates3.Show(); txtbxDates3.Show(); lblJob3.Show();
            txtbxJob3.Show(); lblSummary3.Show(); txtbxSummary3.Show(); btnAddExp2.Hide();
        }

        private void btnEduc_Click(object sender, EventArgs e)
        {
            lblPROFESSIONAL.Hide(); btnAddExp.Hide(); lblCompany.Hide();
            txtbxCompany.Hide(); lblDates.Hide(); txtbxDates.Hide(); lblJob.Hide();
            txtbxJob.Hide(); lblSummary.Hide(); txtbxSummary.Hide(); lblCompany2.Hide();
            txtbxCompany2.Hide(); lblDates2.Hide(); txtbxDates2.Hide(); lblJob2.Hide();
            txtbxJob2.Hide(); lblSummary2.Hide(); txtbxSummary2.Hide(); lblCompany3.Hide();
            txtbxCompany3.Hide(); lblDates3.Hide(); txtbxDates3.Hide(); lblJob3.Hide();
            txtbxJob3.Hide(); lblSummary3.Hide(); txtbxSummary3.Hide();

            lblEDUC.Show();
            lblSchool.Show(); txtbxSchool.Show(); lblGradDate.Show(); txtbxGradDate.Show();
            lblDegree.Show(); txtbxDegree.Show(); lblGPA.Show(); txtbxGPA.Show();
        }
        public class data
        {
            public string LastName { get; set; }
            public string FirstName { get; set; }
            public string MiddleI { get; set; }
            public string Address { get; set;}
            public string Email { get; set; }
            public string ContactNumber { get; set; }
            public string Company { get; set; }
            public string Date { get; set; }
            public string Job { get; set; } 
            public string Summary { get; set; }
            public string Company2 { get; set; }
            public string Date2 { get; set; }
            public string Job2 { get; set; }
            public string Summary2 { get; set; }
            public string Company3 { get; set; }
            public string Date3 { get; set; }
            public string Job3 { get; set; }
            public string Summary3 { get; set; }
            public string educ { get; set; }
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            rchtxtbxRead.Show();
            data Data = new data()
            {
                LastName = txtbxFullName.Text,
                FirstName = txtbxFirst.Text,
                MiddleI = txtbxMiddle.Text,
                Address = txtbxAddress.Text,
                Email = txtbxEmail.Text,
                ContactNumber = txtbxContact.Text,

                Company = txtbxCompany.Text,
                Date = txtbxDates.Text,
                Job = txtbxJob.Text,
                Summary = txtbxSummary.Text,
                Company2 = txtbxCompany2.Text,
                Date2 = txtbxDates2.Text,
                Job2 = txtbxJob2.Text,
                Summary2 = txtbxSummary2.Text,
                Company3 = txtbxCompany2.Text,
                Date3 = txtbxDates2.Text,
                Job3 = txtbxJob2.Text,
                Summary3 = txtbxSummary2.Text,
            
                educ = txtbxSchool.Text + txtbxGradDate.Text + txtbxDegree.Text + txtbxGPA.Text
            };
            string strResultJson = JsonConvert.SerializeObject(Data, Formatting.Indented);
            File.WriteAllText(Application.StartupPath + "\\Json\\" + txtbxFullName.Text + "_" + txtbxFirst.Text +".json", strResultJson);
            PDF();
            MessageBox.Show("Stored!");

            string jsonFromFile;
            using (var reader = new StreamReader(Application.StartupPath + "\\Json\\" + txtbxFullName.Text + "_" + txtbxFirst.Text + ".json"))
            {
                jsonFromFile = reader.ReadToEnd();
            }
            rchtxtbxRead.Text = jsonFromFile;
            var readJson = JsonConvert.DeserializeObject<data>(strResultJson);


        }
        private void PDF()
        {
            PdfDocument pdfDocument = new PdfDocument();
            PdfPage pages = pdfDocument.AddPage();
            XGraphics xGraphics = XGraphics.FromPdfPage(pages);
            xGraphics.DrawString(txtbxFullName.Text + ", " + txtbxFirst.Text + " " + txtbxMiddle.Text,
              new XFont("Lucida Fax", 18, XFontStyle.Bold), XBrushes.Black, new XPoint(50, 50));
            xGraphics.DrawString(txtbxAddress + " " + txtbxFirst.Text + " " + txtbxMiddle.Text,
              new XFont("Lucida Fax", 18, XFontStyle.Bold), XBrushes.Black, new XPoint(50, 50));
            pdfDocument.Save(Application.StartupPath + "\\PDF\\" + txtbxFullName.Text + "_" + txtbxFirst.Text + ".pdf");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
         
           
        }

        private void rchtxtbxRead_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
