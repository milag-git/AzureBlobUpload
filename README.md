.NET 6.0 Razor Pages Repo to upload images to Azure Blob Storage Account. Application deployed on Azure App Service. Turn on Managed Identity for the App service under "Identity". Create Azure Storage Account. Add the App service as 
"Storage Blob Data Contributor" to the Storage Account under IAM Role assignments. "Enable from all networks" and enable "internet Routing" under networking. Enable "Blob Anonymous access" under configuration. Change access level 
on the storage container to "Blob(anonymous read access to blob)"
