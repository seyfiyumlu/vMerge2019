# about vmerge
VMerge can be used to Merge Changsets in TFS version control (TFVC), it is optimized for bulkmerges to not mixup changesets in case you merge several on same time. Also a defined autogenerated chechin commend can be used.

## this adaption

Original vmerge was created as Visual Studio plugin by Alexander Berthold for VS 2012 and VS 2013.
This is the adaption for Visual Studio 2019.

# usage
you should find the tool in the Tool toolbar of visual studio after install the plugin.

Tools / vMerge / Show Changeset view is the best point to get started. Here you can select the Branches you want to merge, and then select the changesets you want to merge. Before a merge is done a dialog is shown were you can decide how to merge.



# error reporting
The plugin logs to folder C:\ProgramData\vMerge2019, feel free to create issus on this project.
