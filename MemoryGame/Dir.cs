using System;
using System.IO;
/// <summary>
/// The class is redundant for the memory game, but can be expanded for further use
/// </summary>
public class Dir
{
    /// <summary>
    /// Contains all the properties regarding the directory
    /// </summary>
    public DirectoryInfo DirInfo { get; private set; }

    /// <summary>
    /// Load a new DirectoryInfo object and assign it to dirInfo property
    /// </summary>
    /// <param name="path"></param>
    public Dir(string path)
    {
        this.DirInfo = new DirectoryInfo(path);
    }

    /// <summary>
    /// Create directory if not exist
    /// </summary>
    public void Create()
    {
        if (!this.DirExists())
        {
            this.DirInfo.Create();
        }
    }


    /// <summary>
    /// Check whether the directory exists
    /// </summary>
    /// <returns>string with path of directory</returns>
    public bool DirExists()
    {
        return this.DirInfo.Exists;
    }

    /// <summary>
    /// Return the full directory path
    /// </summary>
    /// <returns>string with directories full name</returns>
    public string GetDirPath()
    {
        return this.DirInfo.FullName;
    }

    /// <summary>
    /// Delete directory.
    /// forceDelete will delete the content of the directory as well.
    /// </summary>
    /// <param name="forceDelete"></param>
    public void Delete(bool forceDelete = false)
    {
        switch (forceDelete)
        {
            case false:
                this.DirInfo.Delete();
                break;

            case true:
                this.DirInfo.Delete(true);
                break;
        }
    }
}