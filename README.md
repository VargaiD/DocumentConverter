# Document Converter

Welcome!

This program serves as a web API document converter.

For usage please run the web API project and use the swagger UI that should start on your localhost.

Supported Functionality
- GET /document - Loads a document from file system or URL with following parameters: 
  - Location (fileName in case of file system or url in case of file on web)
  - LocationType 
    - -f (file system)
    - -u (url)
  - Format (Format in which the file will be returned, with dot included)
    - .xml
    - .json 
- POST /document - Saves document in specified format, only file system is supported, email is sketched in code
  - Location (fileName in case of file system or url in case of file on web)
  - LocationType 
    - -f (file system)
  - SourceFormat (Format in which the file is right now, with dot included)
    - .xml
    - .json 
  - TargetFormat (Format in which the file will be saved, with dot included)
    - .xml
    - .json 

## Improvements that could be implemented
- Logging of errors and generally improve error handling
- Determine file type on input automatically
- Do not force format of XML and JSON to contain Title and Text properties
- Document Storage in a separate directory and not in API project
- Asynchronous operation so the server is more responsive
- More tests, integration tests that test bigger part of functionality
- AutoMapper to map models between layers
