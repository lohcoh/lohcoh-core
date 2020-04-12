using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lohcode.Documentation
{
    public static class lohrExamples
    {
        public static void ConfigureModel(LohrModel model)
        {
            model.CreateStory(story =>  {
                story.AddSentence<Customer, (sentence => {
                    sentence.Subject<Customer>().Action, Request<
                })
            });
        }
    }
}
