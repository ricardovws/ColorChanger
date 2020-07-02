using System;
using System.Collections.Generic;
using System.Text;

namespace ColorChanger
{
    class Messages
    {
        public string successfulMessage { get; set; }
        public string errorMessage { get; set; }

        public Messages()
        {
            successfulMessage = "That's ok, it's done!";
            errorMessage = "Ouupsi! You didn't choose a valid option.";
        }
    }
}
