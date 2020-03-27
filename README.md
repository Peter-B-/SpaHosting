# SpaHosting
This is a simple test setup for hosting an Angular SPA and APIs on a Azure Function.

The Azure Function Proxy configured in ```proxies.json``` should handle 
 - deep links into the Angular page by redirecting them to ```index.html```
 - direkt access to files in ```/assets``` and ```/```
 - direkt access to all APIs with the route prefix ```/api```
 
 So far the test is not successful, because requests like ```api/users/{userId}/cars``` are not handled correctly.
 
