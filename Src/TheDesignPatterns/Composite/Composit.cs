using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TheDesignPatterns.Composite
{
    /// <summary>
    /// Common interface for File and Folder. It is the component interface of the pattern.
    /// </summary>
    public interface IFileManagement
    {
        string Name { get; set; }
        void Display();
    }

    /// <summary>
    /// Similar to Directory/Folder object. It is the composit object of the pattern
    /// </summary>
    public class FileDirectory : IFileManagement
    {
        private IList<IFileManagement> fileManagementList = new List<IFileManagement>();

        public string Name { get; set; }

        public void Add(IFileManagement fileManagement)
        {            
            fileManagementList.Add(fileManagement);

            if (fileManagement is FileContent)
            {
                var customFile =  fileManagement as FileContent;

                customFile.ParentDirectory = this;
            }
        }

        /// <summary>
        /// Interface memeber
        /// </summary>
        public void Display()
        {
            Debug.WriteLine($"+Directory Name={Name}");

            foreach(IFileManagement fileManagement in fileManagementList)
            {
                fileManagement.Display();
            }
        }
    }

    /// <summary>
    /// Similar to File object. It is the Leaf object of the pattern.
    /// </summary>
    public class FileContent : IFileManagement
    {
        public FileDirectory ParentDirectory { get; set; }
        private StringBuilder contentBuilder = new StringBuilder();
        public string Name { get; set; }

        public void AddContent(string content)
        {
            contentBuilder.Append(content);
        }

        public string GetContent()
        {
            return contentBuilder.ToString();
        }

        /// <summary>
        /// Interface memeber
        /// </summary>
        public void Display()
        {
            Debug.WriteLine($"+File Name={Name}");
        }
    }
}
