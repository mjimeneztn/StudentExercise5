using StudentExercises5.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentExercises5
{
   public class NssPerson
    {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Slack { get; set; }
            public Cohort Cohort { get; set; }
            public string GetFullName()
            {
                return$"{FirstName} {LastName}";
            }
        }
    }

