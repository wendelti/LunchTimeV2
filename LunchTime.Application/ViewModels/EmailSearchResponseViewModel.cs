using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunchTime.Application.ViewModels
{
    public class EmailSearchResponseViewModel
    {
        public enum Result
        {
            InvalidEmail = 0,
            NewUser = 1,
            FindedEmail = 2
        }

        public Result result { get; set; }
        public string msg { get; set; }
    }

}
