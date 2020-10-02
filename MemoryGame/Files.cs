using System;
using System.IO;

/// <summary>
/// Provides basic functionality for handling files.
/// </summary>
public class Files
{
    public string FilePath { get; private set; }

    public Files(string completePath)
    {
        this.FilePath = completePath;
    }

    /// <summary>
    /// Create the file based on whether it already exists or not
    /// If exists, ignore the creation of it
    /// if not, create the file in the designated filepath and dispose it after construction
    /// </summary>
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


    /// <summary>
    /// WriteToFile writes data to a file
    /// parameter overwrite will overwrite the file its contents with the new contents passed along
    /// parameter overwrite is default set to false, preventing files from being overwritten
    /// </summary>
    /// <param name="writeMeToFile"></param>
    /// <param name="overwrite"></param>
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

    /// <summary>
    /// Returns the content that is stored in the file
    /// </summary>
    /// <returns>string Content stored in file</returns>
    public string GetFileContent()
    {
        return File.ReadAllText(this.FilePath);
    }

    /// <summary>
    /// Check whether file exists
    /// </summary>
    /// <returns>Boolean based on if file exists</returns>
    public bool FileExists()
    {
        return File.Exists(this.FilePath);
    }
}