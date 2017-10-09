<div align="center">
<a href="https://github.com/mohan-cao/306P2"><img style="display:inline-block;" src="./bmlogo.png" alt="Our logo WIP"></a>
<br>
<sup>Master branch is currently </sup><a href="https://travis-ci.com/mohan-cao/revilo"><img style="display:inline-block;" src="https://travis-ci.com/mohan-cao/306P2.svg?token=geujzTyWrzPD96doTGqK&branch=master" alt="Build status"></a>
</div>

# Execution Instructions
* Run the .exe
* Use arrow keys to move player
* Walk into a character or item to interact
* Press [space] to interact with NPCs via dialogue
* Talk to NPCs until they finish speaking what you think is relevant, then leave the conversation, or NPCs could continue through randomly generated dialogue
* To go back down stairs, walk around to the other side of the stairs (like escalators)

# Setting Up
1. Set up Git LFS. https://git-lfs.github.com/
2. Set up Unity for Git. 


For versions of Unity 3D v4.3 and up:

1. (Skip this step in v4.5 and up) Enable External option in Unity → Preferences → Packages → Repository.
2. Open the Edit menu and pick Project Settings → Editor:
    1. Switch Version Control Mode to Visible Meta Files.
    2. Switch Asset Serialization Mode to Force Text.
3. Save the scene and project from File menu.

# Adding Binary Files to be Tracked
Since we are gitignoring binary files and large files, we have to use Git large file storage to track changes to these files efficiently.
https://help.github.com/articles/configuring-git-large-file-storage/

Generally, use `git lfs track "*.ext"` to track a file of type extension if you find that the file you want to track is not being added.

# Development Team

| Name         | UPI     | GitHub    |
| ------------ | ------- | --------- |
| Abby Shen    | [ashe848](mailto:ashe848@aucklanduni.ac.nz) | [ashe848](http://www.github.com/ashe848) + commits from 'unknown' |
| Andrew Lyall    | [alya691](mailto:alya691@aucklanduni.ac.nz) | [Scoobster](http://www.github.com/Scoobster) |
| Brad Miller    | [bmil852](mailto:bmil852@aucklanduni.ac.nz) | [bmil852](http://www.github.com/bmil852) + commits from 'unknown' |
| Mohan Cao    | [mcao024](mailto:mcao024@aucklanduni.ac.nz) | [mohan-cao](http://www.github.com/mohan-cao) |
| Michael Kemp | [mkem114](mailto:mkem114@aucklanduni.ac.nz) | [mkem114](http://www.github.com/mkem114)   |
| Sejal Patel    | [spt098](mailto:spt098@aucklanduni.ac.nz) | [sejpat25](http://www.github.com/sejpat25) |
| Sidharth Parthasarathy   | [spar743](mailto:spar743@aucklanduni.ac.nz) | [sidpartha1](http://www.github.com/sidpartha1) |
| Terran Kroft | [tkro003](mailto:tkro003@aucklanduni.ac.nz) | [itemic](http://www.github.com/itemic)    |
