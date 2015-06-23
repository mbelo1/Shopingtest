using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

public static class AdminDataClass
{
    //Haal een beheerder op via zijn unieke email
    public static Beheerder GetBeheerder(string email)
    {
        try
        {
                return DataClass.dbContext.Beheerder.Find(email);
        }
        catch (Exception er)
        {
            throw new Exception(er.Message);
        }
    }

    //beheerder opslaan of updaten
    public static bool SaveBeheerder(Beheerder beheerder, string task)
    {
        try
        {
            //docent opslaan of wijzigen
            switch (task)
            {
                case "Add":
                    //als de beheerder al bestaat niet toevoegen 
                    if (DataClass.dbContext.Beheerder.Find(beheerder.Email) != null)
                        return false;
                    else
                    {
                        //beheerder toevoegen
                        DataClass.dbContext.Beheerder.Add(beheerder);
                        DataClass.dbContext.SaveChanges();
                        return true;
                    }
                case "Update":
                    if (DataClass.dbContext.Beheerder.Find(beheerder.Email) == null)
                        return false;
                    Beheerder oudeBeheerder = DataClass.dbContext.Beheerder.First(d => d.Email == beheerder.Email);
                    oudeBeheerder.Achternaam = beheerder.Achternaam;
                    oudeBeheerder.Voornaam = beheerder.Voornaam;
                    oudeBeheerder.Tussenvoegsels = beheerder.Tussenvoegsels;
                    oudeBeheerder.Email = beheerder.Email;
                    oudeBeheerder.Wachtwoord = beheerder.Wachtwoord;
                    DataClass.dbContext.SaveChanges();
                    return true;
                default:
                    return false;


            }
        }
        catch (Exception er)
        {
            throw new Exception(er.Message);
        }

    }


    //beheerder verwijderen
    public static bool DeleteBeheerder(string email)
    {
        try
        {
            Beheerder beheerder = DataClass.dbContext.Beheerder.Find(email);
            if (beheerder != null)
            {
                DataClass.dbContext.Beheerder.Remove(beheerder);
                DataClass.dbContext.SaveChanges();
                return true;
            }
            else
                return false;
        }
        catch (Exception er)
        {
            throw new Exception(er.Message);
        }
    }

    public static List<Student> ImportStudenten(List<Student> nieuwLijst)
    {
        try
        {
             //eerst klasen aanmaken
        if (SaveKlasen(nieuwLijst))
        {
            //als student nummer al voorkomt wijzig de gegevens
            var Bestaandestudenten = DataClass.dbContext.Student.Where(s => s.Studentnummer != null);
            //eerst iedereen nonactief maken en alleen de nieuwe actief maken
            if(Bestaandestudenten != null)
            {
                foreach(Student student in Bestaandestudenten)
                {
                    student.Actief = false;
                }
            }
            //nu alle nieuwe studenten toevoegen
            foreach(Student student in nieuwLijst)
            {
                Student bestandeSt = DataClass.dbContext.Student.FirstOrDefault(s => s.Studentnummer == student.Studentnummer);
                if (bestandeSt == null)
                DataClass.dbContext.Student.Add(student);

                    //als de student bestaat
                else
                {
                    bestandeSt.Achternaam = student.Achternaam;
                    bestandeSt.Roepnaam = student.Roepnaam;
                    bestandeSt.KlasId = student.KlasId;
                    bestandeSt.Opleiding = student.Opleiding;
                    bestandeSt.OuderID = student.OuderID;
                    bestandeSt.Postcode = student.Postcode;
                    bestandeSt.Telefoon1 = student.Telefoon1;
                    bestandeSt.Telefoon2 = student.Telefoon2;
                    bestandeSt.Tussenvoegsels = student.Tussenvoegsels;
                    bestandeSt.Woonplaats = student.Woonplaats;
                    bestandeSt.Geslacht = student.Geslacht;
                    bestandeSt.Email = student.Email;
                    bestandeSt.Adres = student.Adres;
                    bestandeSt.Actief = student.Actief;
                }
                DataClass.dbContext.SaveChanges();
            }
            
        }

        return DataClass.dbContext.Student.Where(s => s.Actief == false).ToList();
        }
        //((System.Data.Entity.Validation.DbEntityValidationException)er).EntityValidationErrors
        catch(Exception er)
        {
            throw new Exception(er.Message);
        }

       
    }

    //klasen opslaan
    private static bool SaveKlasen(List<Student> nieuwLijst)
    {
        try
        {
            //controle lijst
            List<Klas> nklasen = new List<Klas>();
            foreach (Student student in nieuwLijst)
            {
                //als er all een klas 
                if (nklasen.FirstOrDefault(u => u.KlasNaam == student.Klas.KlasNaam) == null)
                {
                    //controle lijst 
                    nklasen.Add(student.Klas);
                    DataClass.dbContext.Klas.Add(student.Klas);
                    //eerst opslaan om de id te krijgen
                    DataClass.dbContext.SaveChanges();
                    student.KlasId = student.Klas.Id;
                    foreach(Student st in nieuwLijst.Where(s=> s.Klas.KlasNaam == student.Klas.KlasNaam))
                    {
                        st.KlasId = student.KlasId;
                    }
                }
                //ouders opslaan
                if (student.OuderID < 1)
                {
                    //ouder opslaan en aan de huidige studenten en zijn adress genoten toedelen
                    Ouder ouder = new Ouder();
                    ouder.Voornaam = "stWaarde";
                    ouder.Achternaam = "stWaarde";
                    ouder.Email = "stWaarde";
                    ouder.Wachtwoord = "stWaarde";
                    DataClass.dbContext.Ouder.Add(ouder);
                    //eerst opslaan om de id te krijgen
                    DataClass.dbContext.SaveChanges();
                    student.OuderID = ouder.OuderID;

                    ///nu alle studenten op dezelfde adress een ouder id toekennen
                    foreach (Student st in nieuwLijst.Where(s => s.Postcode == student.Postcode && s.Adres == student.Adres && student.OuderID > 1))
                    {
                        st.OuderID = ouder.OuderID;
                    }
                }

            }
            
            return true;
        }
        catch(Exception er)
        {
            throw new Exception(er.Message);
        }
        
    }

    //ouders koppelen
    //private static bool SaveOuders(List<Student> nieuwLijst)
    //{
    //    try
    //    {
    //        foreach(Student student in nieuwLijst)
    //        {
    //            if(student.OuderID < 1)
    //            {
    //                //ouder opslaan en aan de huidige studenten en zijn adress genoten toedelen
    //                Ouder ouder = new Ouder();
    //                ouder.Voornaam = "stWaarde";
    //                ouder.Achternaam = "stWaarde";
    //                ouder.Email = "stWaarde";
    //                ouder.Wachtwoord = "stWaarde";
    //                DataClass.dbContext.Ouder.Add(ouder);
    //                //eerst opslaan om de id te krijgen
    //                DataClass.dbContext.SaveChanges();
    //                student.OuderID = ouder.OuderID;
                    
    //                ///nu alle studenten op dezelfde adress een ouder id toekennen
    //                foreach(Student st in nieuwLijst.Where(s=> s.Postcode == student.Postcode && s.Adres == student.Adres))
    //                {                        
    //                    st.OuderID = ouder.OuderID;
    //                }
                  
    //            }
    //        }
    //        return true;
    //    }
    //    catch(Exception er)
    //    {
    //        throw new Exception("Fout bij het opslaan van ouders");
    //    }
    //}

}



    
}
