using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Win32;
using MyNotepad.Models;

namespace MyNotepad.ViewModels
{
    public class FileViewModel
    {
        public Document_model Document { get; private set; }

        public ICommand NewCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SaveAsCommand { get; }
        public ICommand OpenCommand { get; }

        public FileViewModel(Document_model document)
        {
            Document = document;
            NewCommand = new RelayCommand(NewFile);
            SaveCommand = new RelayCommand(SaveFile);
            SaveAsCommand = new RelayCommand(SaveFileAs);
            OpenCommand = new RelayCommand(OpenFile);            
        }
        
        public void NewFile()
        {
            Document.File_name = string.Empty;
            Document.File_path = string.Empty;
            Document.Text = string.Empty;
        }

        private void SaveFile()
        {
            File.WriteAllText(Document.File_path, Document.Text);
        }

        private void SaveFileAs()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "Text File (*.txt) | *.txt"
            };
            if (saveFileDialog.ShowDialog() == true)
            {
                DockFile(saveFileDialog);
                File.WriteAllText(saveFileDialog.FileName, Document.Text);
            }
        }

        private void OpenFile()
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                DockFile(openFileDialog);
                Document.Text = File.ReadAllText(openFileDialog.FileName);
            }
        }

        private void DockFile<T>(T dialog) where T : FileDialog
        {
            Document.File_path = dialog.FileName;
            Document.File_path = dialog.SafeFileName;
        }
    }
}
