using System;
using System.IO;

/*
 * The class is redundant for the memory game, but can be expanded for further use
 */
public class Dir
{
    /*
     * Create DirectoryInfo object
     * It contains all the properties regarding the directory
     */
    public DirectoryInfo DirInfo { get; private set; }

    /*
     * Load a new DirectoryInfo object and assign it to dirInfo property
     */
    public Dir(string path)
    {
        this.DirInfo = new DirectoryInfo(path);
    }

    /*
     * Create the directory if exists
     * else ignore and do not create
     */
    public void Create()
    {
        if (!this.DirExists())
        {
            this.DirInfo.Create();
        }
    }

    /*
     * Check whether the directory exists
     */
    public bool DirExists()
    {
        return this.DirInfo.Exists;
    }

    /*
     * Get the full directory path
     */
    public string GetDirPath()
    {
        return this.DirInfo.FullName;
    }

    /*
     * Delete directory
     * forceDelete will delete the content of the directory as well
     */
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
