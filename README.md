# CaixaMagica.MunichRE.Quotes


• Write a REST API to create, read, update and delete people and quotes. Include an endpoint to return a random quote of the day and who said it.


Acceptance criteria:

• Use ASP.NET Core.

    Done
• You do not have to worry about authorization and authentication.


• For persistence preferably use Entity Framework Core with SQLite.

    It's using EF6 Core and the SQLite EF Connection Packages
    
• Although this is only a small backend, write it as if it were the beginning of an enterprise-scale solution that will grow large soon.

    Right now it contains a Data layer to store the Context and the models, I would like to have added a Business Logic that multiple Apps could feed of, but I didn't think it was needed for this case.
    
    I also would like to create a layer just for APIs to return data, but for this case creating a folder just to return Random QOTD was enough.
    
    It contains the Interface layer that the user interacts, it's done in MVC using the CRUD scatfolding methods done by VS with the base of the Model created before.
    
    You can create, delete, edit, and view the quotes.
    
    Creating or editing an empty quote will add Empty - Unknown
