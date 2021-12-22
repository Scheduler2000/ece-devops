# Service Level Agreement


### How to determine if a service is available or not ?

The service is available as long as the swagger page is available.
However the service provide a more deticated endpoint, healtcheck at `https://.../api/v1/health`.

### How often do you monitor your services to determine availability ?

The user API is not intended to be used daily and intensively
At the moment, there is an instance of an elk suite (kibana and elasticsearch) at your disposal.
There are no other controls currently in place.
To learn more about kibana and elasticsearch for the application monitoring see the README.md file.

### What SLA does User API offer on connectivity ?

User API operations are not affected by the external service. 

