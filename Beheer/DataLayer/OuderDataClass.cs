using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public static class OuderDataClass
    {
        //een ouder opslaan of updaten
        public static bool SaveOuder(Ouder ouder)
        {
            try
            {
                Ouder dbOuder = DataClass.dbContext.Ouder.FirstOrDefault(o => o.OuderID == ouder.OuderID);
                //ouder updaten
                if (dbOuder != null)
                {
                    dbOuder.Voornaam = ouder.Voornaam;
                    dbOuder.Achternaam = ouder.Achternaam;
                    dbOuder.Email = ouder.Email;
                    dbOuder.Postcode = ouder.Postcode;
                    dbOuder.Telefoon1 = ouder.Telefoon1;
                    dbOuder.Telefoon2 = ouder.Telefoon2;
                    dbOuder.Tussenvoegsels = ouder.Tussenvoegsels;
                    dbOuder.Woonplaats = ouder.Woonplaats;
                    dbOuder.Wachtwoord = ouder.Wachtwoord;
                    DataClass.dbContext.SaveChanges();
                    return true;
                }
                else
                    return false;
            }
            catch(Exception er)
            {
                throw new Exception(er.Message);
            }
            
        }
    }
}
