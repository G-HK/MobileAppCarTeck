using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace CarTeckM.Behaviors 
{
    public class NumericEntry : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }

        private void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {
            // check of het een nummer is en als het een nummer is >0 & <100
            int number;
            var entry = (Entry)sender;
            string entryText = ((Entry)sender).Text;

            if (entryText.Contains("All"))
            {
                entryText = entryText.Replace("All", "");
            }

            bool isValid = int.TryParse(entryText, out number);

            if (isValid && entryText!= "All")
            {
             
                
                if ( int.Parse(entryText) < 0)
                {
                    entryText = 0.ToString();
                }
                else if (int.Parse(entryText) > 2000000)
                {
                    entryText = 2000000.ToString();
                }
                
                
                ((Entry)sender).Text = $"{entryText:N0}";
                
            }
            else
            {
                ((Entry)sender).Text = "All";  //entryText.Remove(entryText.Length - 1);
            }

           // ((Entry)sender).TextColor = (isValid) ? Color.Black : Color.Red;
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }


    }
}
