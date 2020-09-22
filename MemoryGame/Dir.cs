using System;

/*
 * The class is redundant for the memory game, but can be expanded for further use
 */
public class Dir
{
    public DirectoryInfo dirInfo { get; private set; }
    private string path;

    public Dir(string path)
    {
        this.path = path;
        this.dirInfo = new DirectoryInfo(path);
    }

    public void Create()
    {
        if (!this.DirExists())
        {
            this.dirInfo.Create();
        }
    }

    //make this a method in the interface
    //so file and directories can be checked for existance 
    public bool DirExists()
    {
        if (this.dirInfo.Exists)
        {
            return true;
        }
        return false;
    }

    public void Delete(bool forceDelete = false)
    {
        switch (forceDelete)
        {
            case false:
                this.dirInfo.Delete();
                break;

            case true:
                this.dirInfo.Delete(true);
                break;
        }
    }
}
