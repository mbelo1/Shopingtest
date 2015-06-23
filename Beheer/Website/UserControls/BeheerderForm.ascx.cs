using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataLayer;

namespace OAS.UserControls
{
    public partial class BeheerderForm : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void zoekBeheerder_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtBeheerderEmail.Text.Contains('@') && txtBeheerderEmail.Text.Contains('.'))
                {
                    Beheerder beheerder = AdminDataClass.GetBeheerder(txtBeheerderEmail.Text);
                    if (beheerder != null)
                    {
                        txtBeheerderEmail.Text = beheerder.Email;
                        txtBeheerderVoornaam.Text = beheerder.Voornaam;
                        txtBeheerderTussenvoegsel.Text = beheerder.Tussenvoegsels;
                        txtBeheerderAchternaam.Text = beheerder.Achternaam;

                        //als de beheerder bestaat worden alleen de knoppen wijzigen en verwijderen
                        btnAddBeheerder.Enabled = false;
                        btnDeleteBeheerder.Enabled = true;
                        btnUpdateBeheerder.Enabled = true;
                        lblBmode.Text = "Wat kan ik doen: Beheerder bekijken, Wijzigen of verwijderen";
                    }
                    else
                    {
                        //als de beheerder niet voorkomt kan die toegevoegd worden. Knop wordt dan geenabled
                        Response.Write("<script>alert('De beheerder is niet gevonden, Controleer de ingevoerde afkorting en probeer opnieuw of voeg de beheerder toe')</script>");
                        lblBmode.Text = "Wat kan ik doen: Beheerder zoeken of toevoegen";
                        btnAddBeheerder.Enabled = true;
                        btnDeleteBeheerder.Enabled = false;
                        btnUpdateBeheerder.Enabled = false;
                    }
                }
                else
                {
                    lblBmode.Text = "Wat kan ik doen: Beheerder zoeken of toevoegen";
                    Response.Write("<script>alert('De ingevoerde email is niet geldig')</script>");
                    
                }
            }
            catch (Exception er)
            {
                string msg = "<script>alert('Er is iets fout gegaan: " + er.Message + "')</script>";
                //buttons disabelen en velden leeg maken
                ResetButons();
                Response.Write(msg);
            }
        }

        //beheerder toevoegen
        protected void btnAddBeheerder_Click(object sender, EventArgs e)
        {
            try
            {
                //eerst beheerder samenstellen en dan toevoegen
                if (AdminDataClass.SaveBeheerder(SetBeheerderFromPost(), "Add"))
                {
                    Response.Write("<script>alert('De Beheerer is succesvol Toegevoegd')</script>");
                    //buttons disabelen en velden leeg maken
                    ResetButons();

                }
                else
                {
                    Response.Write("<script>alert('Er is iets fout gegaan bij het toevoegen van de docent, Probeer het opniew. Controleer eerst of de docent al voorkomt')</script>");
                }
            }
            catch (Exception er)
            {
                ResetButons();
                Response.Write("<script>alert('Foutmelding: " + er.Message + "')</script>");
            }
        }


        protected void btnUpdateBeheerder_Click(object sender, EventArgs e)
        {
            try
            {
                //eerst een beheerder samenstellen en dan updaten
                if ( AdminDataClass.SaveBeheerder(SetBeheerderFromPost(), "Update"))
                {
                    Response.Write("<script>alert('De beheerder is succesvol Opgeslagen')</script>");
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
         protected void btnDeleteBeheerder_Click(object sender, EventArgs e)
        {
            if (AdminDataClass.DeleteBeheerder(txtBeheerderEmail.Text))
            {
                ResetButons();
                Response.Write("<script>alert('De beheerder is succesvol Verwijdert')</script>");
            }
            else
            {
                Response.Write("<script>alert('Er is iets fout gegaan bij het verwijderen van de beheerders, Probeer het opniew')</script>");
            }
        }

        //uit alle post inputs een beheerder samenstellen
        private Beheerder SetBeheerderFromPost()
        {
            try
            {
                return new Beheerder()
                {
                    Voornaam = txtBeheerderVoornaam.Text,
                    Achternaam = txtBeheerderAchternaam.Text,
                    Tussenvoegsels = txtBeheerderTussenvoegsel.Text,
                    Email = txtBeheerderEmail.Text,
                    Wachtwoord = txtBeheerderWachtwoord.Text
                };
            }
            catch
            {
                return null;
            }

        }

        //alle velden naar null zetten
        private void ResetButons()
        {
            btnAddBeheerder.Enabled = false;
            btnDeleteBeheerder.Enabled = false;
            btnUpdateBeheerder.Enabled = false;
            lblBmode.Text = "Wat kan ik doen: Beheerder Zoeken";
            //velden weer leeg maken

            foreach (var control in this.Controls)
            {
                var textbox = control as TextBox;
                if (textbox != null)
                    textbox.Text = string.Empty;
            }

        }
    }
}