# Setting up
1. Set up Git LFS. https://git-lfs.github.com/
2. Set up Unity for Git. 


For versions of Unity 3D v4.3 and up:

1. (Skip this step in v4.5 and up) Enable External option in Unity → Preferences → Packages → Repository.
2. Open the Edit menu and pick Project Settings → Editor:
  1. Switch Version Control Mode to Visible Meta Files.
  2. Switch Asset Serialization Mode to Force Text.
3. Save the scene and project from File menu.


# Adding binary files to be tracked
Since we are gitignoring binary files and large files, we have to use Git large file storage to track changes to these files efficiently.
https://help.github.com/articles/configuring-git-large-file-storage/

Generally, use `git lfs track "*.ext"` to track a file of type extension if you find that the file you want to track is not being added.
