using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using DataLayer;

namespace OAS.UserControls
{
    public partial class StudentenForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            //string appdataMap = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //List<string> veldNamen = new List<string>();
            if(StudentenUpload.HasFile)
            {
                string veldNamen = StudentenUpload.PostedFile.ToString();
                var reader = new StreamReader(StudentenUpload.PostedFile.InputStream);
                List<Student> Studenten = new List<Student>();
                bool firstLine = true;
                try
                {
                    #region Studenten lijst samenstellen
                    while (!reader.EndOfStream)
                    {
                        if (firstLine == true)
                        {
                            var line = reader.ReadLine();
                            firstLine = false;
                            continue;
                        }
                        //studenten toevoegen aan een lijst, waardens worden op specifieke indexes verwacht
                        var values = reader.ReadLine().Split(';');
                        //datum veld splitsen
                        string[] gebDatum = values[9].Split('-');
                        Studenten.Add(
                            new Student()
                            {
                                Studentnummer = values[0],
                                Klas = new Klas() { KlasNaam = values[1], AangemaaktOp = DateTime.Now},
                                Roepnaam = values[2],
                                Tussenvoegsels = values[3],
                                Achternaam = values[4],
                                Adres = values[5],
                                Postcode = values[6],
                                Woonplaats = values[7],
                                Telefoon1 = values[8],
                                GeboorteDatum = new DateTime(Convert.ToInt32(gebDatum[2]), Convert.ToInt32(gebDatum[1]), Convert.ToInt32(gebDatum[0])),
                                Geslacht = values[11],
                                Telefoon2 = values[13],
                                Opleiding = values[15],
                                Email = values[18],
                                Actief = true
                            }
                            );
                    }
                    #endregion
                    List<Student> stud = AdminDataClass.ImportStudenten(Studenten);
                }
                catch(Exception er)
                {
                    throw new Exception(er.Message);
                }
                    
                
            }
           
        }
    }
}