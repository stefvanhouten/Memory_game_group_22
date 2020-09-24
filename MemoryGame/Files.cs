using System;
using System.IO;

public class Files
{
    public string FilePath { get; private set; }

    public Files(string completePath)
    {
        this.FilePath = completePath;
    }

    /*
     * Create the file based on whether it already exists or not
     * If exists, ignore the creation of it
     * if not, create the file in the designated filepath and dispose it after construction
     */
    public void Create()
    {
        if (!this.FileExists())
        {
            using (FileStream fs = File.Create(this.FilePath))
            {
                /*
                 * "using" statement is being used here, to dispose the ongoing process once it's finished
                 * This ensures the next process won't be halted due to the file being open.
                 */
            }
        }
    }

    /*
     * WriteToFile writes data to a file
     * parameter overwrite will overwrite the file its contents with the new contents passed along
     * parameter overwrite is default set to false, preventing files from being overwritten
     */
    public void WriteToFile(string writeMeToFile, bool overwrite = false)
    {
        if (overwrite)
        {
            File.WriteAllText(this.FilePath, writeMeToFile);
        }
        else
        {
            /*
             * Append the text to the file and dispose the process.
             * Disposing the process prevents the code from coming to halt when the same file gets accessed again
             * ADDINITIONAL INFO:
             * StreamWriter implements a TextWriter for writing characters to a stream in a particular encoding.
             */
            using (StreamWriter sw = File.AppendText(this.FilePath))
            {
                sw.WriteLine(writeMeToFile);
            }
        }
    }

    /*
     * Return the contents of a file to the client
     */
    public string GetFileContent()
    {
        return File.ReadAllText(this.FilePath);
    }

    /*
     * Check whether file exists
     */
    public bool FileExists()
    {
        return File.Exists(this.FilePath);
    }
}