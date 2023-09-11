using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotepad.Models
{
    public class Document_model : Observaible_object
    {
        private string text;
        public string Text
        {
            get => text;
            set => OnPropertyChanged(ref text, value);
        }

        private string file_path;
        public string File_path
        {
            get => file_path;
            set => OnPropertyChanged(ref file_path, value);
        }

        private string file_name;
        public string File_name
        {
            get => file_name;
            set => OnPropertyChanged(ref file_name, value);
        }

        public bool IsEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(File_name) || string.IsNullOrEmpty(File_path))
                    return true;

                return false;
            }
        }
    }
}
