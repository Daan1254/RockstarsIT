using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsIT_DAL.Templates
{
    //In repository en interface ervoor maken in BLL
    public class EmailTemplateDAL
    {
        public string GetTemplateByName(string templateName)
        {  
            if (templateName == "SurveyEmailTemplate")
                {
                    return @"
                        <html>
                        <body>
                            Beste, <br> 
                                U bent uitgenodigd om de volgende enquête in te vullen: <br> <br> 
                                <b>{{SurveyTitle}}</b> <br> 
                                {{SurveyDescription}} <br> <br> 
                                Klik op de volgende link om de enquête in te vullen: <br> 
                                <a href=""{{SurveyLink}}"">Klik hier om de enquête in te vullen</a>
                        </body>
                        </html>";
                }

             return null;
        }
    }
}
