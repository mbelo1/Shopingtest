using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace OAS.UserControls
{
    public partial class DocentForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            dllKlas.DataSource = DocentDataClass.LaatsToegevoegdKlasen();
            dllKlas.DataBind();
        }

        //docent gegevens opzoeken via zijn/haar afkorting
        /// <summary>
        /// Handles the Click event of the zoekDocent control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void zoekDocent_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtDocentAfkorting.Text.Length >= 5)
                {
                    Docent docent = DocentDataClass.GetDocent(txtDocentAfkorting.Text);
                    if(docent != null)
                    {
                        txtDocentAfkorting.Text = docent.Afkorting;
                        txtDocentVoornaam.Text = docent.Voornaam;
                        txtDocentTussenvoegsel.Text = docent.Tussenvoegsels;
                        txtDocentAchternaam.Text = docent.Achternaam;                        
                        txtDocentEmail.Text = docent.Email;
                        txtDocentTelefoon1.Text = docent.Telefoon1;
                        txtDocentTelefoon2.Text = docent.Telefoon2;
                        txtDocentWachtwoord.Text = docent.Wachtwoord;
                        cbDocentIsactief.Checked = docent.Isactief;

                        //als de docent voorkomt worden de buttons wijzigen en verwijderen geactiveert
                        btnAddDocent.Enabled = false;
                        btnDeleteDocent.Enabled = true;
                        btnUpdateDocent.Enabled = true;

                        lblMode.Text = "Wat kan ik doen: docent bekijken, wijzigen of verwijderen";
                    }
                    else
                    {
                        Response.Write("<script>alert('De docent is niet gevonden, Controleer de ingevoerde afkorting en probeer het opnieuw of voeg de docent toe')</script>");
                        //komt de coent niet voor dan kan die toegevoegd worden
                        btnAddDocent.Enabled = true;
                        btnDeleteDocent.Enabled = false;
                        btnUpdateDocent.Enabled = false;
                        lblMode.Text = "Wat kan ik doen: Docent zoeken of toevoegen";
                    }
                }
                else
                {
                    Response.Write("<script>alert('De ingevoerde afkorting is tekort, Controleer deze en probeer het opnieuw')</script>");
                    //als de afkorting neit klopt wordt geen knop ge-enablet
                    ResetButons();
                }
            }
            catch(Exception er)
            {
                string msg = "<script>alert('Foutmelding: " + er.Message + "')</script>";
                Response.Write(msg);
                //bij een error ook geen knop enabelen
                ResetButons();
                
            }
            
        }

      
        //docent toevoegen 
        protected void btnAddDocent_Click(object sender, EventArgs e)
        {
            try
            {
                //eerst docent samenstellen en dan toevoegen
                if (DocentDataClass.SaveDocent(SetDocentFromPost(), "Add"))
                {
                    Response.Write("<script>alert('De Docent is succesvol Toegevoegd')</script>");
                    //buttons disabelen en velden leeg maken
                    ResetButons();
                    
                }
                else
                {
                    Response.Write("<script>alert('Er is iets fout gegaan bij het toevoegen van de docent, Probeer het opniew. Controleer eerst of de docent al voorkomt')</script>");
                }
            }
            catch(Exception er)
            {
                //buttons disabelen en velden leeg maken
                ResetButons();
                Response.Write("<script>alert('Foutmelding: " + er.Message + "')</script>");
            }
            
        }


        //docent opslaan of updaten
        protected void btnUpdateDocent_Click(object sender, EventArgs e)
        {
            try
            {
                //eerst een docent samenstellen en dan updaten
                if (DocentDataClass.SaveDocent(SetDocentFromPost(), "Update"))
                {
                    Response.Write("<script>alert('De Docent is succesvol Opgeslagen')</script>");
                    ResetButons();
                    
                }
                else
                {
                    Response.Write("<script>alert('Er is iets fout gegaan bij het opslaan van de docent, Probeer het opniew. Controleer eerst of de docent al voorkomt')</script>");
                    
                }
            }
            catch (Exception er)
            {
                
                Response.Write("<script>alert('Foutmelding: " + er.Message + "')</script>");
            }
        }

        //docent verwijderen
        /// <summary>
        /// Verwijdert Docent.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        protected void btnDeleteDocent_Click(object sender, EventArgs e)
        {
            if(DocentDataClass.DeleteDocent(txtDocentAfkorting.Text))
            {
                ResetButons();
                Response.Write("<script>alert('De Docent is succesvol Verwijdert')</script>");
            }
            else
            {
                Response.Write("<script>alert('Er is iets fout gegaan bij het opslaan van de docent, Probeer het opniew')</script>");
            }
        }

        //buttons disabelen en velden leeg maken
        /// <summary>
        /// Resets the butons.
        /// </summary>
        private void ResetButons()
        {
            btnAddDocent.Enabled = false;
            btnDeleteDocent.Enabled = false;
            btnUpdateDocent.Enabled = false;
            lblMode.Text = "Wat kan ik doen: Docent Zoeken";
            //velden weer leeg maken

            foreach( var control in this.Controls )
            {
                var textbox = control as TextBox;
                if (textbox != null)
                textbox.Text = string.Empty;
            }

        }

        //uit alle post inputs een docent samenstellen
        private Docent SetDocentFromPost()
        {
            try
            {
                //als er geen klas is geselecteerd geen klasnaam opgeven
                string klas = null;
                if (dllKlas.SelectedValue != "")
                {
                    klas = dllKlas.SelectedValue;
                }
                return new Docent()
                {
                    Afkorting = txtDocentAfkorting.Text,
                    Voornaam = txtDocentVoornaam.Text,
                    Achternaam = txtDocentAchternaam.Text,
                    Tussenvoegsels = txtDocentTussenvoegsel.Text,
                    Email = txtDocentEmail.Text,
                    Telefoon1 = txtDocentTelefoon1.Text,
                    Telefoon2 = txtDocentTelefoon2.Text,
                    Wachtwoord = txtDocentWachtwoord.Text,
                    Isactief = cbDocentIsactief.Checked
                    
                };
            }
            catch
            {
                return null;
            }

        }

        


    }
}