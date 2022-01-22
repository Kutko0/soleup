using System.Collections.Generic;

namespace Soleup.API.Services
{
    public class ResponseMessages  
    {  
        // START Declaration of Drop messages
        IDictionary<string, string> DropMessages = new Dictionary<string, string>{
            {"ITEM_TAKEN", ""},
            {"WON_ITEM", ""},
            {"YOUR_ITEM", ""},
        };
        // END 
        IDictionary<string, string> GeneralMessages = new Dictionary<string, string>{
            {"EMAIL_TAKEN", ""},
            {"FIELDS_REQUIRED", ""},
        };


    }  
}