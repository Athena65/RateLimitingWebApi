# RateLimitingWebApi
#### This project provides you to avoid unnecessary pressure against your API server by limiting someones repeatedly request to your server. 
Rate Limiting would stop malicious activities like DDos attacks or bot activities. By implementing this code a developer can minimize the cost for API provider. 
#### Less Requests(HTTP) less Money.
#### If you try get request in Weatherforecast more then 5 calls within 10 seconds you will get response like this:
![ratelimiting](https://user-images.githubusercontent.com/41066333/215482195-88c71391-e221-4fbf-be90-f400e95e0fd2.png)
#### And if you wanna add new IP rules using Post Request you should use **RateLimiting Controller** to include rate limit policies rules for specific IPs. *Instead* of doing like this:
![busekildeyapmakyerine](https://user-images.githubusercontent.com/41066333/215484983-17de0432-23b0-4eeb-8d5b-7e46c03741c3.png)
