using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMauiPart10.Model
{
    public class Result
    {
        public string zip { get; set; }
        public string city { get; set; }
        public string state { get; set; }
    }

    public class Root
    {
        public List<Result> results { get; set; }
    }

}
