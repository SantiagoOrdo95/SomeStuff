using System;

namespace ClientMongoApp.Application.Client.Responses
{
    public record ClientResponse( 
        string Name,
        string Last_name,
        string Document_id,
        string Address,
        DateTime Creation_date
    );
}
