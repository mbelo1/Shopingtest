using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

public static class DocentDataClass
{
    //docent ophalen via zijn afkorting
	public static Docent  GetDocent( string afkorting)
	{
        try
        {
            return DataClass.dbContext.Docent.Find(afkorting);
        }
        catch(Exception er)
        {
            throw new Exception(er.Message);
        }
        
	}

    //docent opslaan(wijzigen of toevoegen)
    public static bool SaveDocent(Docent docent, string task)
    {
        try
        {
            //docent opslaan of wijzigen
            switch (task)
            {
                case "Add":
                    //als de docent al bestaat niet toevoegen 
                    if (DataClass.dbContext.Docent.Find(docent.Afkorting) != null)
                        return false;
                    else
                    {
                        //docent toevoegen
                        DataClass.dbContext.Docent.Add(docent);
                        DataClass.dbContext.SaveChanges();
                        return true;
                    }
                case "Update":
                    if (DataClass.dbContext.Docent.Find(docent.Afkorting) == null)
                        return false;
                    Docent oudeDocent = DataClass.dbContext.Docent.First(d => d.Afkorting == docent.Afkorting);
                    oudeDocent.Achternaam = docent.Achternaam;
                    oudeDocent.Voornaam = docent.Voornaam;
                    oudeDocent.Tussenvoegsels = docent.Tussenvoegsels;
                    oudeDocent.Email = docent.Email;
                    oudeDocent.Telefoon1 = docent.Telefoon1;
                    oudeDocent.Telefoon2 = docent.Telefoon2;
                    oudeDocent.Wachtwoord = docent.Wachtwoord;
                    oudeDocent.Isactief = docent.Isactief;
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

    //docent verwijderen
    public static bool DeleteDocent(string afkorting)
    {
        try
        {
            Docent docent = DataClass.dbContext.Docent.Find(afkorting);
            if (docent != null)
            {
                DataClass.dbContext.Docent.Remove(docent);
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

    //klassen uit de laatste studenten lijst ophalen
    public static List<Klas> LaatsToegevoegdKlasen()
    {
        try
        {
            List<Klas> laatsteKlassen = new List<Klas>();
            var lastId = DataClass.dbContext.spLastKlas().FirstOrDefault();
        if(lastId > 0)
        {
            var klas = DataClass.dbContext.Klas.Where(k => k.Id == lastId).FirstOrDefault();
            if(klas != null)
            laatsteKlassen = DataClass.dbContext.Klas.Where(k => k.AangemaaktOp == klas.AangemaaktOp).ToList();
        }
        return laatsteKlassen;
        }
        catch(Exception er)
        {
            throw new Exception(er.Message);
        }
        
    }
    //public virtual void GetMoment(object int id)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public virtual void GetDocent(object int id)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public virtual void SetDeadline(object DateTime dealine, object int docentId)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public virtual void AddMoment(object DateTime datum, object int id)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public virtual void CreateSubMomenten(object Int MomentId)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public virtual void UpdateDocent(object Docent objDocent)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public virtual void CancelGesprek(object Int submomentId)
    //{
    //    throw new System.NotImplementedException();
    //}

    //public virtual void AddGespreksVerslag(object int SubmomentId)
    //{
    //    throw new System.NotImplementedException();
    //}



    }
}
